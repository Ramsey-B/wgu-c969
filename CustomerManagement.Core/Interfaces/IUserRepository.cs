using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(User user);
        Task<int> CreateAsync(User user);
    }
}
