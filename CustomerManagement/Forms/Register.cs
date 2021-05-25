using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.ViewModels;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Register : Form
    {
        private readonly ITranslator _translator;
        private readonly RegisterViewModel _viewModel;

        public Register(IContext context)
        {
            InitializeComponent();
            _translator = context.GetService<ITranslator>();
            _viewModel = new RegisterViewModel(context);
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
            exitBtn.Text = _translator.Translate("exit");
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
            try
            {
                await _viewModel.Register(new Core.Models.User
                {
                    Username = username.Text,
                    Password = password.Text,
                    Active = true,
                    CreatedBy = username.Text,
                    LastUpdatedBy = username.Text
                }, confirmPasswordInput.Text);
                Close();
            }
            catch (PublicException ex)
            {
                switch (ex.Id)
                {
                    case "invalid-username":
                        usernameError.Visible = true;
                        usernameError.Text = ex.Message;
                        break;
                    case "invalid-password":
                        passwordError.Visible = true;
                        passwordError.Text = ex.Message;
                        break;
                    case "unexpected-error":
                        loginError.Visible = true;
                        loginError.Text = ex.Message;
                        break;
                }
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
