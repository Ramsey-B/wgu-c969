using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GetAppointments().Wait();

            // this is a event hook that gets the appointments after the user selects a year
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

            var monthCount = new Dictionary<string, int>()
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
            result.ForEach(r =>
            {
                monthCount[r.Start.Month.ToString()]++;
            });
            var report = new List<AppointmentReport>();
            foreach (var month in monthCount)
            {
                report.Add(new AppointmentReport() { Month = month.Key, Count = month.Value });
            }

            TableService.SetData(ref reportTable, report);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}