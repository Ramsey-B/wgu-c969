﻿using System.Threading.Tasks;
using CustomerManagement.Core.Models;

namespace CustomerManagement.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> CreateAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        Task<int> DeleteAsync(int id);
        Task<Customer> GetAsync(int id);
    }
}
