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
                var user = await _userRepository.LoginAsync(new User() { Name = username.Text, Password = password.Text });

                _logger.LogMessage($"User with username ({user.Name}) and id ({user.Id}) successfully logged in.");
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
            cancelBtn.Text = _translator.Translate("cancel");
            loginBtn.Text = _translator.Translate("login.login");
        }

        private void hideErrors()
        {
            usernameError.Visible = false;
            passwordError.Visible = false;
            loginError.Visible = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); // stop the app if the user wont log in.
        }
    }
}
