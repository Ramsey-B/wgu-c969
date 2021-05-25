using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Context : IContext
    {
        private readonly IServiceProvider _servicePorvider;
        private User _currentUser;
        public static Form InitForm;

        public Context(IServiceProvider serviceProvider)
        {
            _servicePorvider = serviceProvider; // used for dependecy injection.
        }

        public User CurrentUser
        {
            get { return _currentUser; }
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

        private static INavigationPage currentPage;
        public void Navigate(INavigationPage page)
        {
            page.Show();
            if (currentPage != null) currentPage.Close();
            currentPage = page;
        }

        private bool exited = false;
        public void Exit()
        {
            Application.Exit();
            exited = true;
        }

        private int loginCount = 0;
        public User Authenticate()
        {
            while (_currentUser == null) // keep forcing the login till the user is set.
            {
                if (exited) return null;
                if (loginCount > 5)
                {
                    Exit();
                    break;
                }
                var login = new Login(this);
                login.ShowDialog();
                loginCount++;
            }
            return _currentUser;
        }
    }
}
