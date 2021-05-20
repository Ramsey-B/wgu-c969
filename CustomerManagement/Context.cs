using CustomerManagement.Core.Models;
using CustomerManagement.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Context
    {
        private readonly IServiceProvider _servicePorvider;
        private User _currentUser;

        public Context(IServiceProvider serviceProvider)
        {
            _servicePorvider = serviceProvider; // used for dependecy injection.
        }

        public User CurrentUser
        {
            get { return Authenticate(); }
            set { _currentUser = value; }
        }

        /// <summary>
        /// Gets a registered service by type.
        /// Used so we only need to pass the context to 
        /// sub forms instead of all dependencies.
        /// </summary>
        public T GetService<T>()
        {
            return _servicePorvider.GetRequiredService<T>();
        }

        private static Form currentForm;
        public void Navigate(Form form)
        {
            form.Show();
            if (currentForm != null) currentForm.Close();
            currentForm = form;
        }

        private User Authenticate()
        {
            while (_currentUser == null) // keep forcing the login till the user is set.
            {
                var login = new Login(this);
                login.ShowDialog(); // If the current user is unknown, display the login.
            }
            return _currentUser;
        }
    }
}
