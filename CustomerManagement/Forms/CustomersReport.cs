using CustomerManagement.Core.Interfaces;
using CustomerManagement.Tables;
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
    public partial class CustomersReport : Form
    {
        private readonly Context _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly Translator _translator;

        public CustomersReport(Context context)
        {
            _context = context;
            _customerRepository = context.GetService<ICustomerRepository>();
            _translator = context.GetService<Translator>();
            InitializeComponent();
            Translate();
            Init();
        }

        private void Init()
        {
            var report = _customerRepository.GetCustomerReportsAsync(_context.CurrentUser.Id).Result;
            TableService.SetData(ref reportTable, report);
        }

        private void Translate()
        {
            Name = _translator.Translate("customersReport");
            Text = _translator.Translate("customersReport");
            pageHeader.Text = _translator.Translate("customersReport");
            closeBtn.Text = _translator.Translate("close");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
