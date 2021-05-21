using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class CustomerSelect : Form
    {
        private readonly IContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly Translator _translator;
        private List<Customer> customers;

        public Customer Customer { get; set; } // This allows the parent to grab the selected Customer

        public CustomerSelect(IContext context)
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
            customers.FindAll(c => c.Active);
            var items = customers.Select(c => new Core.Models.CustomerSelect() { Name = c.Name });
            TableService.SetData(ref customersTable, items.ToList(), key => _translator.Translate($"customerSelect.{key}"));
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            var index = customersTable.CurrentRow.Index;
            Customer = customers[index]; 
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
