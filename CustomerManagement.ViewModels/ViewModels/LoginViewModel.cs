using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class LoginViewModel
    {
        private readonly IContext _context;
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public LoginViewModel(IContext context)
        {
            _context = context;
            _logger = context.GetService<ILogger>();
            _userRepository = context.GetService<IUserRepository>();
        }

        public async Task Login(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new PublicException("invalid-username");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new PublicException("invalid-password");
            }

            try
            {
                var u = await _userRepository.LoginAsync(user);

                _logger.LogMessage($"User with username ({u.Username}) and id ({u.Id}) successfully logged in.");
                _context.CurrentUser = u;
            }
            catch (InvalidLoginException ex)
            {
                _logger.LogMessage($"Failed login attempt with Username {ex.Username}");
                throw new PublicException("invalid-login");
            }
            catch (Exception)
            {
                throw new PublicException("unexpected-login");
            }
        }
    }
}
