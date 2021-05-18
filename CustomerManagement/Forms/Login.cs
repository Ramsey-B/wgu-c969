using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Logging;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Login : Form
    {
        private readonly Context _context;
        private readonly Logger _logger;
        private readonly Translator _translator;
        private readonly IUserRepository _userRepository;

        public Login(Context context)
        {
            InitializeComponent();
            _context = context;
            _logger = context.GetService<Logger>();
            _translator = context.GetService<Translator>();
            _userRepository = context.GetService<IUserRepository>();
            TranslatePage();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            hideErrors(); // resets the error messages
            var isValid = true;
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                usernameError.Visible = true;
                usernameError.Text = _translator.Translate("login.usernameError");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password.Text))
            {
                passwordError.Visible = true;
                passwordError.Text = _translator.Translate("login.passwordError");
                isValid = false;
            }

            if (!isValid) return; // stop execution is inputs are invalid

            try
            {
                var user = await _userRepository.LoginAsync(new User() { Username = username.Text, Password = password.Text });

                _logger.LogMessage($"User with username ({user.Username}) and id ({user.Id}) successfully logged in.");
                _context.CurrentUser = user;
                Close();
            }
            catch (InvalidLoginException ex)
            {
                _logger.LogMessage($"Failed login attempt with Username {ex.Username}");
                loginError.Visible = true;
                loginError.Text = _translator.Translate("login.loginError");
            }
            catch (Exception)
            {
                loginError.Visible = true;
                loginError.Text = _translator.Translate("unexpectedError");
            }
        }

        private void TranslatePage()
        {
            Name = _translator.Translate("login.pageTitle");
            Text = _translator.Translate("login.pageTitle");
            pageHeader.Text = _translator.Translate("login.pageHeader");
            usernameLabel.Text = _translator.Translate("login.username");
            passwordLabel.Text = _translator.Translate("login.password");
            registerBtn.Text = _translator.Translate("login.register");
            loginBtn.Text = _translator.Translate("login.login");
        }

        private void hideErrors()
        {
            usernameError.Visible = false;
            passwordError.Visible = false;
            loginError.Visible = false;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            var register = new Register(_context);
            register.Show();

            register.FormClosed += (object s, FormClosedEventArgs ec) =>
            {
                if (_context.CurrentUser != null) Close();
            };
        }

        private void pageHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
