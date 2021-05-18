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
        Task<User> CreateAsync(User user);
        Task<bool> CheckUsernameExists(string username);
    }
}
