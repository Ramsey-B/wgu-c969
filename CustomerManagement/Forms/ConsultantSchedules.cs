using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class ConsultantSchedules : Form
    {
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Translator _translator;

        public ConsultantSchedules(Context context)
        {
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
            _translator = _context.GetService<Translator>();
            InitializeComponent();
            Translate();
            _ = AddCrewNames();
            _ = GetReport();

            monthRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = false;
                monthRadio.Checked = true;
                await GetReport();
            };

            weekRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = true;
                monthRadio.Checked = false;
                await GetReport();
            };

            dayRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = true;
                weekRadio.Checked = false;
                monthRadio.Checked = false;
                await GetReport();
            };
        }

        private async Task AddCrewNames()
        {
            var now = DateTime.UtcNow;
            var start = new DateTime(now.Year, now.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);
            var appointments = await _appointmentRepository.GetAllAsync(start, end);
            var crewNames = appointments.Select(a => a.Crew).OrderBy(c => c).ToList();

            var all = _translator.Translate("all");
            crewSelect.Items.Add(all);
            crewNames.ForEach(n => crewSelect.Items.Add(n));
            crewSelect.SelectedItem = all;
            crewSelect.SelectedValueChanged += async (object sender, EventArgs e) => await GetReport();
        }

        private async Task GetReport()
        {
            var now = DateTime.UtcNow;
            DateTime start;
            DateTime end;
            if (monthRadio.Checked)
            {
                start = new DateTime(now.Year, now.Month, 1); // first day of the month
                end = start.AddMonths(1).AddDays(-1); // last day of month
            }
            else if (weekRadio.Checked)
            {
                start = now.AddDays(-(int)now.DayOfWeek); // first day of the week
                end = start.AddDays(7); // last day of the week
            }
            else
            {
                start = new DateTime(now.Year, now.Month, now.Day); // start of day
                end = new DateTime(now.Year, now.Month, now.Day).AddDays(1).AddSeconds(-1); // end of day
            }
            var crew = crewSelect.SelectedItem == null || crewSelect.SelectedItem.ToString() == _translator.Translate("all") ? null : crewSelect.SelectedItem.ToString();
            var results = await _appointmentRepository.GetConsultantSchedules(start, end, crew) ?? new List<ConsultantSchedule>();

            TableService.SetData(ref reportTable, results, (key) => _translator.Translate($"consultantSchedules.{key}"));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await GetReport();
        }

        private void Translate()
        {
            Name = _translator.Translate("consultantSchedules.pageTitle");
            Text = _translator.Translate("consultantSchedules.pageTitle");
            pageHeader.Text = _translator.Translate("consultantSchedules.pageHeader");
            monthRadio.Text = _translator.Translate("month");
            weekRadio.Text = _translator.Translate("week");
            closeBtn.Text = _translator.Translate("close");
        }
    }
}
