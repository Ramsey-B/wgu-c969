using CustomerManagement.Core.Interfaces;
using CustomerManagement.Logging;
using CustomerManagement.Translations;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Register : Form
    {
        private readonly IContext _context;
        private readonly Logger _logger;
        private readonly Translator _translator;
        private readonly IUserRepository _userRepository;

        public Register(IContext context)
        {
            InitializeComponent();
            _context = context;
            _logger = context.GetService<Logger>();
            _translator = context.GetService<Translator>();
            _userRepository = context.GetService<IUserRepository>();
            TranslatePage();

            langSelect.Items.Add("English");
            langSelect.Items.Add("Ingles");
            langSelect.SelectedItem = "English";
            langSelect.SelectedValueChanged += (object sender, EventArgs e) =>
            {
                switch (langSelect.SelectedItem)
                {
                    case "English":
                        _translator.SetLanguage(Languages.English);
                        break;
                    case "Ingles":
                        _translator.SetLanguage(Languages.Spanish);
                        break;
                }
                TranslatePage();
            };
        }



        private void TranslatePage()
        {
            Name = _translator.Translate("register.pageTitle");
            Text = _translator.Translate("register.pageTitle");
            pageHeader.Text = _translator.Translate("register.pageHeader");
            usernameLabel.Text = _translator.Translate("register.username");
            passwordLabel.Text = _translator.Translate("register.password");
            confirmPasswordLabel.Text = _translator.Translate("register.confirmPassword");
            cancelBtn.Text = _translator.Translate("cancel");
            createBtn.Text = _translator.Translate("register.create");
        }

        private void hideErrors()
        {
            usernameError.Visible = false;
            passwordError.Visible = false;
            confirmError.Visible = false;
            loginError.Visible = false;
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            hideErrors();
            var isValid = true;

            if (username.Text.Length < 4)
            {
                usernameError.Text = _translator.Translate("register.usernameError", new { charCount = 4 });
                usernameError.Visible = true;
                isValid = false;
            }

            if (isValid && await _userRepository.CheckUsernameExists(username.Text))
            {
                usernameError.Text = _translator.Translate("register.usernameTakenError", new { username = username.Text });
                usernameError.Visible = true;
                isValid = false;
            }

            if (password.Text.Length < 8 ||
                !password.Text.Any(char.IsNumber) ||
                !password.Text.Any(char.IsUpper) ||
                !password.Text.Any(char.IsLower) ||
                !password.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                passwordError.Text = _translator.Translate("register.passwordError");
                passwordError.Visible = true;
                isValid = false;
            }

            if (!isValid) return;

            if (password.Text != confirmPasswordInput.Text)
            {
                confirmError.Text = _translator.Translate("register.confirmPasswordError");
                confirmError.Visible = true;
                return;
            }

            try
            {
                var user = await _userRepository.CreateAsync(new Core.Models.User
                {
                    Username = username.Text,
                    Password = password.Text,
                    Active = true,
                    CreatedBy = username.Text,
                    LastUpdatedBy = username.Text
                });
                _logger.LogMessage($"Created user ({user.Username}) with id ({user.Id}) successfully.");
                _context.CurrentUser = user;
                Close();
            }
            catch (Exception)
            {
                loginError.Visible = true;
                loginError.Text = _translator.Translate("unexpectedError");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
