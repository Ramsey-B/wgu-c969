using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Sql;
using System;
using System.Collections.Generic;
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
    }
}
