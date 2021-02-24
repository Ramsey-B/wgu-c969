﻿using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
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
        private BindingList<Customer> customers;

        public Dashboard(Context context, Translator translator, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            _context = context;
            _customerRepository = customerRepository;
            _translator = translator;
            Shown += async (object sender, EventArgs e) =>
            {
                await getCustomers();
                customersTable.Columns["AddressId"].Visible = false;
                customersTable.Columns["Address"].Visible = false;
            };
        }

        private async Task getCustomers()
        {
            var results = await _customerRepository.GetAllAsync();
            customers = new BindingList<Customer>(results);
            var customersBinding = new BindingSource();
            customersBinding.DataSource = customers;
            customersTable.DataSource = customersBinding;
        }

        private void addBtn_Click(object s, System.EventArgs e)
        {
            var modifyCustomer = new ModifyCustomer(_context.CurrentUser, _translator, _customerRepository);
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private void editBtn_Click(object s, System.EventArgs e)
        {
            var customer = customersTable.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }

            var modifyCustomer = new ModifyCustomer(_context.CurrentUser, _translator, _customerRepository, customer.Id);
            modifyCustomer.FormClosed += async (object sender, FormClosedEventArgs ev) =>
            {
                await getCustomers();
            };
            modifyCustomer.ShowDialog();
        }

        private async void deleteBtn_Click(object sender, System.EventArgs e)
        {
            var customer = customersTable.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }

            var dialogResult = MessageBox.Show(_translator.Translate("customer.confirmDelete", new { customer.Name }), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            try
            {
                await _customerRepository.DeleteAsync(customer.Id);
                await getCustomers();
            }
            catch (System.Exception)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }

        private void appointmentsBtn_Click(object sender, EventArgs e)
        {
            var customer = customersTable.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }
            new Appointments(_context, customer).Show();
        }
    }
}