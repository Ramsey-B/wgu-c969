﻿using CustomerManagement.Core.Models;
using CustomerManagement.Forms;
using CustomerManagement.Translations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Context
    {
        private readonly Login _login;
        private readonly IServiceProvider _servicePorvider;
        private User _currentUser;

        public Context(Login login, IServiceProvider serviceProvider)
        {
            _login = login;
            _servicePorvider = serviceProvider;

            _login.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                _currentUser = _login.User;
            };
        }

        public User CurrentUser
        {
            get { return Authenticate(); }
            set { _currentUser = value; }
        }

        public Languages CurrentLanguage => GetCurrentLanguage();

        public T GetService<T>()
        {
            return _servicePorvider.GetRequiredService<T>();
        }

        private Languages GetCurrentLanguage()
        {
            switch (CultureInfo.CurrentUICulture.LCID)
            {
                case 2058:
                    return Languages.Spanish;
                default:
                    return Languages.English;
            }
        }

        private User Authenticate()
        {
            if (_currentUser == null)
            {
                _login.ShowDialog();
            }
            return _currentUser;
        }
    }
}