﻿using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Logging;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Login : Form
    {
        private readonly Logger _logger;
        private readonly Translator _translator;
        private readonly IUserRepository _userRepository;
        public User User;

        public Login(Logger logger, Translator translator, IUserRepository userRepository)
        {
            InitializeComponent();
            _logger = logger;
            _translator = translator;
            _userRepository = userRepository;
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

            var user = await _userRepository.LoginAsync(new User() { Name = username.Text, Password = password.Text });

            if (user == null)
            {
                loginError.Visible = true;
                loginError.Text = _translator.Translate("login.loginError");
                return;
            }

            _logger.LogMessage($"User with username ({user.Name}) and id ({user.Id}) successfully logged in.");
            User = user;
            Close();
        }

        private void hideErrors()
        {
            usernameError.Visible = false;
            passwordError.Visible = false;
            loginError.Visible = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}