using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Tables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms.Customers
{
    public partial class Dashboard : Form, INavigationPage
    {
        private readonly IContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITranslator _translator;
        private readonly User _currentUser;
        private List<Customer> _customers;

        public Dashboard(IContext context)
        {
            InitializeComponent();
     
            _context = context;
            _customerRepository = _context.GetService<ICustomerRepository>();
            _translator = _context.GetService<ITranslator>();
            _currentUser = context.CurrentUser; // Triggers auth
            if (_currentUser == null) Application.Exit(); // exit if the user wont log in

            Translate();

            _ = getCustomers();
            var reminder = _context.GetService<Reminder>();
            _ = reminder.HandleAppointmentReminders(); // Do not await this so it doesn't block the main thread.
        }

        private async Task getCustomers(string searchTerm = "")
        {
            _customers = await _customerRepository.GetAllAsync(searchTerm);
            TableService.SetData<Customer>(ref customersTable, _customers, key => _translator.Translate($"customer.{key}"));
        }

        private void addBtn_Click(object s, EventArgs e)
        {
            var modifyCustomer = new ModifyCustomer(_currentUser, _translator, _customerRepository);
            // Refresh the customer data after the form is closed
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private void editBtn_Click(object s, EventArgs e)
        {
            var index = customersTable.CurrentRow.Index;
            var customer = _customers[index];

            var modifyCustomer = new ModifyCustomer(_currentUser, _translator, _customerRepository, customer.Id);
            // Refresh the customer data after the form is closed
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var index = customersTable.CurrentRow.Index;
            var customer = _customers[index];

            var dialogResult = MessageBox.Show(_translator.Translate("customer.confirmDelete", new { name = customer.Name }), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            try
            {
                await _customerRepository.DeleteAsync(customer.Id);
                await getCustomers();
            }
            catch (Exception)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }

        private void appointmentsBtn_Click(object sender, EventArgs e)
        {
            var index = customersTable.CurrentRow.Index;
            var customer = _customers[index];
            if (customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }
            var appointments = new Appointments(_context, customer);
            _context.Navigate(appointments);
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

        private void Translate()
        {
            Name = _translator.Translate("dashboard.pageTitle");
            Text = _translator.Translate("dashboard.pageTitle");
            pageHeader.Text = _translator.Translate("dashboard.pageHeader", new { Username = _context.CurrentUser.Username });
            customersBtn.Text = _translator.Translate("customers");
            calendarBtn.Text = _translator.Translate("calendar");
            reportsBtn.Text = _translator.Translate("reports");
            tableHeader.Text = _translator.Translate("dashboard.tableHeader");
            searchBtn.Text = _translator.Translate("search");
            appointmentsBtn.Text = _translator.Translate("dashboard.viewAppointments");
            deleteBtn.Text = _translator.Translate("delete");
            editBtn.Text = _translator.Translate("edit");
            addBtn.Text = _translator.Translate("add");
            exitBtn.Text = _translator.Translate("exit");
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            var reports = new Reports(_context);
            _context.Navigate(reports);
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await getCustomers(searchInput.Text);
            searchInput.Text = "";
        }
    }
}
