using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using CustomerManagement.Logging;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Login : Form
    {
        private readonly IContext _context;
        private readonly ITranslator _translator;
        private readonly LoginViewModel _viewModel;

        public Login(IContext context)
        {
            InitializeComponent();
            _context = context;
            _translator = context.GetService<ITranslator>();
            _viewModel = new LoginViewModel(context);
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

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            hideErrors(); // resets the error messages
            try
            {
                await _viewModel.Login(new User() { Username = username.Text, Password = password.Text });
                Close();
            }
            catch (PublicException ex)
            {
                switch (ex.Id)
                {
                    case "invalid-username":
                        usernameError.Visible = true;
                        usernameError.Text = _translator.Translate("login.usernameError");
                        break;
                    case "invalid-password":
                        passwordError.Visible = true;
                        passwordError.Text = _translator.Translate("login.passwordError");
                        break;
                    case "invalid-login":
                        loginError.Visible = true;
                        loginError.Text = _translator.Translate("login.loginError");
                        break;
                    case "unexpected-login":
                        loginError.Visible = true;
                        loginError.Text = _translator.Translate("unexpectedError");
                        break;
                }
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
            register.ShowDialog();
            Close();
        }

        private void pageHeader_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            _context.Exit();
        }
    }
}
