using CustomerManagement.Core.Interfaces;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class CustomersReport : Form
    {
        private readonly IContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITranslator _translator;

        public CustomersReport(IContext context)
        {
            _context = context;
            _customerRepository = context.GetService<ICustomerRepository>();
            _translator = context.GetService<ITranslator>();
            InitializeComponent();
            Translate();
            Init();
        }

        private void Init()
        {
            var report = _customerRepository.GetCustomerReportsAsync(_context.CurrentUser.Id).Result;
            TableService.SetData(ref reportTable, report, key => _translator.Translate($"customersReport.{key}"));
        }

        private void Translate()
        {
            Name = _translator.Translate("customersReport.pageTitle");
            Text = _translator.Translate("customersReport.pageTitle");
            pageHeader.Text = _translator.Translate("customersReport.pageHeader");
            closeBtn.Text = _translator.Translate("close");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
