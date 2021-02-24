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

            var customerId = await _sqlOrm.CreateEntityAsync("customer", CreateSql.Customer, customer, new
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

        private void ValidateCustomerInputs(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name) || !Regex.Match(customer.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidCustomerException("name");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.PostalCode) || !customer.Address.PostalCode.All(char.IsDigit))
            {
                throw new InvalidCustomerException("postalCode");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.Address1))
            {
                throw new InvalidCustomerException("address1");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.Phone) || !customer.Address.Phone.All(char.IsDigit))
            {
                throw new InvalidCustomerException("phone");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.City.Name) || !Regex.Match(customer.Address.City.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidCustomerException("city");
            }

            if (string.IsNullOrWhiteSpace(customer.Address.City.Country.Name) || !Regex.Match(customer.Address.City.Country.Name, "^[\\sA-z'-]*$").Success)
            {
                throw new InvalidCustomerException("country");
            }
        }
    }
}
