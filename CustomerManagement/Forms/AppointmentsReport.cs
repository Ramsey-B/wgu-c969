using CustomerManagement.Core.Interfaces;
using CustomerManagement.ViewModels;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class AppointmentsReport : Form
    {
        private readonly IContext _context;
        private readonly ITranslator _translator;
        private readonly AppointmentsReportViewModel _viewModel;

        public AppointmentsReport(IContext context)
        {
            InitializeComponent();
            _context = context;
            _translator = context.GetService<ITranslator>();
            _viewModel = new AppointmentsReportViewModel(context);
            Init();
        }

        private void Init()
        {
            var currentDate = DateTime.UtcNow;
            var reportYears = new object[]
            {
                currentDate.Year + 1,
                currentDate.Year,
                currentDate.Year - 1,
                currentDate.Year - 2,
                currentDate.Year - 3,
                currentDate.Year - 4
            };

            Translate();
            yearSelect.Items.AddRange(reportYears);
            yearSelect.SelectedItem = currentDate.Year;
            GetAppointments().Wait();

            // this is a event hook that gets the appointments after the user selects a year
            yearSelect.SelectedValueChanged += async (object sender, EventArgs e) =>
            {
                await GetAppointments();
            };
        }

        private void Translate()
        {
            Name = _translator.Translate("appointmentsReport.pageTitle");
            Text = _translator.Translate("appointmentsReport.pageTitle");
            pageHeader.Text = _translator.Translate("appointmentsReport.pageHeader");
            closeBtn.Text = _translator.Translate("close");
        }

        private async Task GetAppointments()
        {
            var reports = await _viewModel.GetAppointmentReports((int)yearSelect.SelectedItem);

            TableService.SetData(ref reportTable, reports, key => _translator.Translate(key));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}