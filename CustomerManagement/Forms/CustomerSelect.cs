using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
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
    public partial class CustomerSelect : Form
    {
        private readonly Context _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly Translator _translator;
        private List<Customer> customers;

        public Customer Customer { get; set; } // This allows the parent to grab the selected Customer

        public CustomerSelect(Context context)
        {
            _context = context;
            _customerRepository = _context.GetService<ICustomerRepository>();
            _translator = _context.GetService<Translator>();
            InitializeComponent();
            Translate();

            Init();
        }

        private void Init()
        {
            customers = _customerRepository.GetAllAsync().Result;

            var displayCustomers = new BindingList<object>();
            customers.ForEach(customer =>
            {
                displayCustomers.Add(new
                {
                    customer.Id,
                    customer.Name,
                    customer.Active
                });
            });
            var customersBinding = new BindingSource();
            customersBinding.DataSource = displayCustomers;
            customersTable.DataSource = customersBinding;
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            var customerId = (int)customersTable.CurrentRow.Cells["Id"].Value;
            Customer = customers.Find(c => c.Id == customerId); // Find the customer by Id or return null. Used so I don't need to implement my own search alg
            if (Customer == null)
            {
                MessageBox.Show(_translator.Translate("customer.noneSelected"));
                return;
            }
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Translate()
        {
            pageHeader.Text = _translator.Translate("customerSelect.pageHeader");
            Name = _translator.Translate("customerSelect.pageTitle");
            Text = _translator.Translate("customerSelect.pageTitle");
            cancelBtn.Text = _translator.Translate("cancel");
            selectBtn.Text = _translator.Translate("select");
        }
    }
}
