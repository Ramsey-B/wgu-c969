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
            var addressId = await _addressRepository.CreateAsync(customer.Address);

            var customerId = await _sqlOrm.CreateEntityAsync(CreateSql.Customer, new
            {
                customer.Name,
                AddressId = addressId,
                customer.Active,
                CreateDate = DateTime.UtcNow,
                customer.CreatedBy,
                LastUpdate = DateTime.UtcNow,
                customer.LastUpdateBy
            });

            return customerId;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            ValidateCustomerInputs(customer);
            var rowCount = await _addressRepository.UpdateAsync(customer?.Address);

            if (customer != null)
            {
                rowCount = await _sqlOrm.ExecuteAsync(UpdateSql.Customer, new
                {
                    customer.Id,
                    customer.Name,
                    AddressId = customer.Address.Id,
                    customer.Active,
                    LastUpdate = DateTime.UtcNow,
                    customer.LastUpdateBy
                });
            }

            return rowCount;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _sqlOrm.DeleteAsync(id, "customer");
        }

        public async Task<Customer> GetAsync(int id)
        {
            var customer = await _sqlOrm.QueryAsync<Customer>(SelectSql.Customer, "customer", id);
            customer.Address = await _addressRepository.GetAsync(customer.AddressId);
            return customer;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _sqlOrm.QueryListAsync<Customer>(SelectSql.Customer);
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

            if (string.IsNullOrWhiteSpace(customer.Address.PostalCode) || !customer.Address.PostalCode.All(char.IsDigit))
            {
                throw new InvalidEntityException("postalCode");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.Address1))
            {
                throw new InvalidEntityException("address1");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.Phone) || !customer.Address.Phone.All(char.IsDigit))
            {
                throw new InvalidEntityException("phone");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.City.Name) || !Regex.Match(customer.Address.City.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidEntityException("city");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.City.Country.Name) || !Regex.Match(customer.Address.City.Country.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidEntityException("country");
            }
        }
    }
}
