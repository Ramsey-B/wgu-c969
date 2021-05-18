using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Sql;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ISqlOrm _sqlOrm;
        public UserRepository(ISqlOrm sqlOrm)
        {
            _sqlOrm = sqlOrm;
        }

        public async Task<bool> CheckUsernameExists(string username)
        {
            var result = await _sqlOrm.ExecuteAsync(SelectSql.UsernameCount, new { username });
            return result > 0;
        }

        public async Task<User> LoginAsync(User user)
        {
            user.Password = HashPassword(user.Password);
            var result = await _sqlOrm.QueryAsync<User>(SelectSql.User, user);
            if (result == null)
            {
                throw new InvalidLoginException(user.Username);
            }
            result.Password = null; // ensures the password is never returned.
            return result;
        }

        public async Task<User> CreateAsync(User user)
        {
            user.Password = HashPassword(user.Password);
            user.CreatedDate = DateTime.UtcNow;
            user.LastUpdated = DateTime.UtcNow;

            _ = await _sqlOrm.CreateEntityAsync(CreateSql.User, user);
            var result = await _sqlOrm.QueryAsync<User>(SelectSql.User, user);
            result.Password = null;
            return result;
        }

        /// <summary>
        /// We one way hash the password so the password can be safely stored in the DB.
        /// During login we just rehash the input password and compare it to the one in the DB.
        /// Because the hashing is done the same during creation and login, it should match.
        /// But if someone gains access to the DB, they still wont know the users password.
        /// </summary>
        private string HashPassword(string password)
        {
            using (var sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }
        }
    }
}
