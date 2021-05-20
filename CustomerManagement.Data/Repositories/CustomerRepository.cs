using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlOrm _sqlOrm;
        private readonly IAddressRepository _addressRepository;
        public CustomerRepository(ISqlOrm sqlOrm)
        {
            _sqlOrm = sqlOrm;
            _addressRepository = new AddressRepository(sqlOrm);
        }

        public async Task<int> CreateAsync(Customer customer)
        {
            ValidateCustomerInputs(customer);
            var addressId = await _addressRepository.CreateAsync(new Address
            {
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                CreatedBy = customer.CreatedBy,
                LastUpdatedBy = customer.LastUpdatedBy,
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                City = new City
                {
                    Name = customer.City,
                    CreatedBy = customer.CreatedBy,
                    LastUpdatedBy = customer.LastUpdatedBy,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow,
                    Country = new Country
                    {
                        Name = customer.Country,
                        CreatedBy = customer.CreatedBy,
                        LastUpdatedBy = customer.LastUpdatedBy,
                        CreatedDate = DateTime.UtcNow,
                        LastUpdated = DateTime.UtcNow,
                    }
                }
            });

            customer.AddressId = addressId;
            customer.CreatedDate = DateTime.UtcNow;
            customer.LastUpdated = DateTime.UtcNow;
            var customerId = await _sqlOrm.CreateEntityAsync(CreateSql.Customer, customer);

            return customerId;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            ValidateCustomerInputs(customer);
            var rowsChanged = await _addressRepository.UpdateAsync(new Address
            {
                Id = customer.AddressId,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                LastUpdatedBy = customer.LastUpdatedBy,
                LastUpdated = DateTime.UtcNow,
                City = new City
                {
                    Id = customer.CityId,
                    Name = customer.City,
                    LastUpdatedBy = customer.LastUpdatedBy,
                    LastUpdated = DateTime.UtcNow,
                    Country = new Country
                    {
                        Id = customer.CountryId,
                        Name = customer.Country,
                        LastUpdatedBy = customer.LastUpdatedBy,
                        LastUpdated = DateTime.UtcNow,
                    }
                }
            });

            customer.LastUpdated = DateTime.UtcNow;
            await _sqlOrm.ExecuteAsync(UpdateSql.Customer, customer);

            return rowsChanged += 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _sqlOrm.DeleteAsync(id, "customer");
        }

        public async Task<Customer> GetAsync(int id)
        {
            var customer = await _sqlOrm.QueryAsync<Customer>(SelectSql.Customer + " WHERE customer.id = @id", new { id });
            return customer;
        }

        public async Task<List<Customer>> GetAllAsync(string searchTerm = "")
        {
            var sql = SelectSql.Customer;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                sql += "WHERE name LIKE @searchTerm OR createdBy LIKE @searchTerm";
            }
            var customers = await _sqlOrm.QueryListAsync<Customer>(sql, new { searchTerm });
            return customers;
        }

        public async Task<List<CustomerReport>> GetCustomerReportsAsync(int userId)
        {
            var reports = await _sqlOrm.QueryListAsync<CustomerReport>(SelectSql.CustomerReport, new { UserId = userId });

            var groups = reports.GroupBy(report => report.Id); // group the reports by customer Id

            var reportList = new List<CustomerReport>();
            // Combine individual customers reports into 1
            foreach (var group in groups)
            {
                var report = new CustomerReport
                {
                    Id = group.Key,
                    CustomerName = group.FirstOrDefault()?.CustomerName,
                    AppointmentCount = group.Count(),
                };
                report = SetLastAndNextAppointment(group.ToList(), report);
                reportList.Add(report);
            }

            return reportList;
        }

        private CustomerReport SetLastAndNextAppointment(List<CustomerReport> data, CustomerReport report)
        {
            var pastAppts = new List<DateTime>(); // appointments before now
            var upcomingAppts = new List<DateTime>(); // appointments after now

            // splits the reports by if they're before or after now
            foreach (var item in data)
            {
                if (item.LastAppointment < DateTime.UtcNow)
                {
                    pastAppts.Add(item.LastAppointment.GetValueOrDefault());
                }
                else
                {
                    upcomingAppts.Add(item.LastAppointment.GetValueOrDefault());
                }
            }

            report.LastAppointment = pastAppts.Count > 0 ? (DateTime?)pastAppts.Max() : null; // gets the most recent past appointment time
            report.NextAppointment = upcomingAppts.Count > 0 ? (DateTime?)upcomingAppts.Min() : null; // gets the next appointment time
            return report;
        }

        private void ValidateCustomerInputs(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name) || !Regex.Match(customer.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidEntityException("name");
            }

            if (string.IsNullOrWhiteSpace(customer.PostalCode) || !customer.PostalCode.All(char.IsDigit))
            {
                throw new InvalidEntityException("postalCode");
            }

            if (string.IsNullOrWhiteSpace(customer.Address1))
            {
                throw new InvalidEntityException("address1");
            }

            if (string.IsNullOrWhiteSpace(customer.Phone) || !customer.Phone.All(char.IsDigit))
            {
                throw new InvalidEntityException("phone");
            }

            if (string.IsNullOrWhiteSpace(customer.City) || !Regex.Match(customer.City, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidEntityException("city");
            }

            if (string.IsNullOrWhiteSpace(customer.Country) || !Regex.Match(customer.Country, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidEntityException("country");
            }
        }
    }
}
