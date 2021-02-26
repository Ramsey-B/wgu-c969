using CustomerManagement.Core.Interfaces;
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
    public partial class AppointmentsReport : Form
    {
        private readonly Context _context;
        private readonly Translator _translator;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsReport(Context context)
        {
            InitializeComponent();
            _context = context;
            _translator = context.GetService<Translator>();
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
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

            yearSelect.Items.AddRange(reportYears);
            yearSelect.SelectedItem = currentDate.Year;
            GetAppointments();

            yearSelect.SelectedValueChanged += async (object sender, EventArgs e) =>
            {
                await GetAppointments();
            };
        }

        private async Task GetAppointments()
        {
            var startDate = new DateTime((int)yearSelect.SelectedItem, 1, 1);
            var endDate = startDate.AddYears(1).AddDays(-1);
            var result = await _appointmentRepository.GetAllAsync(startDate, endDate, _context.CurrentUser.Id);

            var report = new Dictionary<string, int>()
            {
                { "1", 0 }, // Jan
                { "2", 0 }, // Feb
                { "3", 0 }, // Mar
                { "4", 0 }, // April
                { "5", 0 }, // May
                { "6", 0 }, // June
                { "7", 0 }, // July
                { "8", 0 }, // Aug
                { "9", 0 }, // Sep
                { "10", 0 }, // Oct
                { "11", 0 }, // Nov
                { "12", 0 }, // Dec
            };

            result.ForEach(appt =>
            {
                report[appt.Start.Month.ToString()]++;
            });

            var displayData = new Dictionary<string, int>();
            foreach (var keyVal in report)
            {
                displayData.Add(_translator.Translate("months." + keyVal.Key), keyVal.Value);
            }

            var appointmentBinding = new BindingSource();
            appointmentBinding.DataSource = displayData;
            reportTable.DataSource = appointmentBinding;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}