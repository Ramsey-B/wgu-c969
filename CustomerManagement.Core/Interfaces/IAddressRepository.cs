using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<int> CreateAsync(Address newAddress);

        Task<int> UpdateAsync(Address address);
        Task<Address> GetAsync(int id);
    }
}
