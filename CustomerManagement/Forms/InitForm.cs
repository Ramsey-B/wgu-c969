using CustomerManagement.Core.Interfaces;
using CustomerManagement.Forms.Customers;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class InitForm : Form
    {
        private readonly Context _context;

        public InitForm(Context context)
        {
            InitializeComponent();
            _context = context;
            var dashboard = new Dashboard(_context);
            _context.Navigate(dashboard);
            dashboard.Shown += (object sender, EventArgs e) => Hide();
        }
    }
}
