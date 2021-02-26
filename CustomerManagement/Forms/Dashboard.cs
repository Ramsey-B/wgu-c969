using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms.Customers
{
    public partial class Dashboard : Form
    {
        private readonly Context _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly Translator _translator;
        private readonly User _currentUser;
        private readonly IAppointmentRepository _appointmentRepository;
        private List<Customer> _customers;

        public Dashboard(Context context, Translator translator, ICustomerRepository customerRepository, IAppointmentRepository appointmentRepository, IUserRepository userRepository)
        {
            InitializeComponent();
     
            _context = context;
            _customerRepository = customerRepository;
            _translator = translator;
            _currentUser = context.CurrentUser; // Triggers auth
            if (_currentUser == null) Application.Exit();
            _appointmentRepository = appointmentRepository;
            Shown += async (object sender, EventArgs e) =>
            {
                await getCustomers();
            };
        }

        private async Task getCustomers()
        {
            _customers = await _customerRepository.GetAllAsync();

            var displayCustomers = new BindingList<object>();
            _customers.ForEach(customer =>
            {
                displayCustomers.Add(new
                {
                    customer.Id,
                    customer.Name,
                    customer.Active,
                    CreatedDate = customer.CreateDate.ToLocalTime(),
                    customer.CreatedBy,
                    LastUpdated = customer.LastUpdate.ToLocalTime(),
                    customer.LastUpdateBy
                });
            });
            var customersBinding = new BindingSource();
            customersBinding.DataSource = displayCustomers;
            customersTable.DataSource = customersBinding;
        }

        private void addBtn_Click(object s, System.EventArgs e)
        {
            var modifyCustomer = new ModifyCustomer(_currentUser, _translator, _customerRepository);
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private void editBtn_Click(object s, System.EventArgs e)
        {
            var customerId = (int)customersTable.CurrentRow.Cells["Id"].Value;

            var modifyCustomer = new ModifyCustomer(_currentUser, _translator, _customerRepository, customerId);
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private async void deleteBtn_Click(object sender, System.EventArgs e)
        {
            var customerId = (int)customersTable.CurrentRow.Cells["Id"].Value;
            var name = customersTable.CurrentRow.Cells["Name"].Value.ToString();

            var dialogResult = MessageBox.Show(_translator.Translate("customer.confirmDelete", new { name }), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            try
            {
                await _customerRepository.DeleteAsync(customerId);
                await getCustomers();
            }
            catch (System.Exception)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }

        private void appointmentsBtn_Click(object sender, EventArgs e)
        {
            var customerId = (int)customersTable.CurrentRow.Cells["Id"].Value;
            var customer = _customers.Find(c => c.Id == customerId);
            if (customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }
            var appointments = new Appointments(_context, _translator, _appointmentRepository, customer);
            appointments.Show();
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            var appointments = new Appointments(_context, _translator, _appointmentRepository);
            appointments.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
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
