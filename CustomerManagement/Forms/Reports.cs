using CustomerManagement.Forms.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Reports : Form
    {
        private readonly Context _context;

        public Reports(Context context)
        {
            InitializeComponent();
            _context = context;
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard(_context);
            _context.Navigate(dashboard);
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            var appointments = new Appointments(_context);
            _context.Navigate(appointments);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void apptNumReportBtn_Click(object sender, EventArgs e)
        {
            new AppointmentsReport(_context).ShowDialog();
        }

        private void consultantReportBtn_Click(object sender, EventArgs e)
        {
            new ConsultantSchedules(_context).ShowDialog();
        }

        private void customerReportBtn_Click(object sender, EventArgs e)
        {
            new CustomersReport(_context).ShowDialog();
        }
    }
}
