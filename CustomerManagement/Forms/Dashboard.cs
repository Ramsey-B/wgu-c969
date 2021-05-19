﻿using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Tables;
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

        public Dashboard(Context context, Translator translator, ICustomerRepository customerRepository, IAppointmentRepository appointmentRepository, Reminder reminder)
        {
            InitializeComponent();
     
            _context = context;
            _customerRepository = customerRepository;
            _translator = translator;
            _appointmentRepository = appointmentRepository;
            _currentUser = context.CurrentUser; // Triggers auth
            if (_currentUser == null) Application.Exit(); // exit if the user wont log in

            Translate();

            _ = getCustomers();
            _ = reminder.HandleAppointmentReminders(); // Do not await this so it doesn't block the main thread.
        }

        private async Task getCustomers(string searchTerm = "")
        {
            _customers = await _customerRepository.GetAllAsync(searchTerm);
            TableService.SetData<Customer>(ref customersTable, _customers);
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
            var customerId = (int)customersTable.CurrentRow.Cells["Id"].Value;

            var modifyCustomer = new ModifyCustomer(_currentUser, _translator, _customerRepository, customerId);
            // Refresh the customer data after the form is closed
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
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
            catch (Exception)
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

        private void Translate()
        {
            Name = _translator.Translate("dashboard.pageTitle");
            Text = _translator.Translate("dashboard.pageTitle");
            pageHeader.Text = _translator.Translate("dashboard.pageHeader", new { Username = _context.CurrentUser.Username });
            calendarBtn.Text = _translator.Translate("dashboard.calendar");
            appointmentsBtn.Text = _translator.Translate("dashboard.viewAppointments");
            deleteBtn.Text = _translator.Translate("delete");
            editBtn.Text = _translator.Translate("edit");
            addBtn.Text = _translator.Translate("add");
            apptNumReportBtn.Text = _translator.Translate("dashboard.appointmentCountReport");
            consultantReportBtn.Text = _translator.Translate("dashboard.consultantReport");
            customerReportBtn.Text = _translator.Translate("dashboard.customerReport");
            exitBtn.Text = _translator.Translate("exit");
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {

        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await getCustomers(searchInput.Text);
            searchInput.Text = "";
        }
    }
}
