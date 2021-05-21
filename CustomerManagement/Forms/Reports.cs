using CustomerManagement.Core.Interfaces;
using CustomerManagement.Forms.Customers;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Reports : Form
    {
        private readonly IContext _context;
        private readonly Translator _translator;

        public Reports(IContext context)
        {
            InitializeComponent();
            _context = context;
            _translator = _context.GetService<Translator>();
        }

        private void Translate()
        {
            customersBtn.Text = _translator.Translate("customers");
            calendarBtn.Text = _translator.Translate("calendar");
            reportsBtn.Text = _translator.Translate("reports");
            exitBtn.Text = _translator.Translate("exit");
            Name = _translator.Translate("reportsPage.pageTitle");
            Text = _translator.Translate("reportsPage.pageTitle");
            apptNumReportBtn.Text = _translator.Translate("reportsPage.numberOfApppiontments");
            consultantReportBtn.Text = _translator.Translate("reportsPage.consultantSchedules");
            customerReportBtn.Text = _translator.Translate("reportsPage.customerReport");
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
