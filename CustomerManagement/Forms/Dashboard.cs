using CustomerManagement.Core.Models;
using CustomerManagement.Forms.Customers;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Dashboard : Form
    {
        private readonly UserContext _userContext;
        private readonly ViewCustomers _viewCustomers;
        private readonly User user;

        public Dashboard(UserContext userContext, ViewCustomers viewCustomers)
        {
            InitializeComponent();

            _userContext = userContext;
            _viewCustomers = viewCustomers;
            user = _userContext.CurrentUser;
        }

        private void viewCustomersBtn_Click(object sender, System.EventArgs e)
        {
            _viewCustomers.Show();
        }
    }
}
