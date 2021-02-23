using CustomerManagement.Core.Models;
using CustomerManagement.Forms;
using CustomerManagement.Translations;
using System.Globalization;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class UserContext
    {
        private Login _login;
        private User _currentUser;

        public UserContext(Login login)
        {
            _login = login;

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
