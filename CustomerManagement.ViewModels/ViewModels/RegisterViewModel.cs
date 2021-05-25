using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class RegisterViewModel
    {
        private readonly IContext _context;
        private readonly ILogger _logger;
        private readonly ITranslator _translator;
        private readonly IUserRepository _userRepository;

        public RegisterViewModel(IContext context)
        {
            _context = context;
            _logger = context.GetService<ILogger>();
            _translator = context.GetService<ITranslator>();
            _userRepository = context.GetService<IUserRepository>();
        }
        public async Task Register(User user, string confirmPassword)
        {
            if (user.Username.Length < 4)
            {
                throw new PublicException("invalid-username", _translator.Translate("register.usernameError", new { charCount = 4 }));
            }

            if (await _userRepository.CheckUsernameExists(user.Username))
            {
                throw new PublicException("invalid-username", _translator.Translate("register.usernameTakenError", new { username = user.Username }));
            }

            if (user.Password.Length < 8 ||
                !user.Password.Any(char.IsNumber) ||
                !user.Password.Any(char.IsUpper) ||
                !user.Password.Any(char.IsLower) ||
                !user.Password.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new PublicException("invalid-password", _translator.Translate("register.passwordError"));
            }

            if (user.Password != confirmPassword)
            {
                throw new PublicException("invalid-password", _translator.Translate("register.confirmPasswordError"));
            }

            try
            {
                var u = await _userRepository.CreateAsync(new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Active = true,
                    CreatedBy = user.Username,
                    LastUpdatedBy = user.Username
                });
                _logger.LogMessage($"Created user ({u.Username}) with id ({u.Id}) successfully.");
                _context.CurrentUser = u;
            }
            catch (Exception)
            {
                throw new PublicException("unxpected-error", _translator.Translate("unexpectedError"));
            }
        }
    }
}
