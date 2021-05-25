using CustomerManagement.Core.Interfaces;
using CustomerManagement.Forms.Customers;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class InitForm : Form
    {
        private readonly IContext _context;

        public InitForm(IContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void InitForm_Load(object s, EventArgs ev)
        {
            _context.Authenticate();

            if (_context.CurrentUser != null)
            {
                var dashboard = new Dashboard(_context);
                _context.Navigate(dashboard);
                dashboard.Shown += (object sender, EventArgs e) => Hide();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
