using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
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
            GetReport().Wait();
        }

        private async Task GetReport()
        {
            var now = DateTime.UtcNow;
            DateTime start;
            DateTime end;
            if (monthRadio.Checked)
            {
                start = new DateTime(now.Year, now.Month, 1);
                end = start.AddMonths(1).AddDays(-1);
            }
            else
            {
                start = now.AddDays(-(int)now.DayOfWeek);
                end = start.AddDays(7);
            }
            var results = await _appointmentRepository.GetAllAsync(start, end, searchTerm: searchBox.Text) ?? new List<Appointment>();

            results = results.OrderBy(appt => appt.Username).ToList(); // sorts the results by their username

            // map the results to the table
            var displayAppt = new BindingList<object>();
            results.ForEach(appt =>
            {
                displayAppt.Add(new
                {
                    appt.Username,
                    appt.CustomerName,
                    appt.Title,
                    appt.Type,
                    appt.Contact,
                    Start = appt.Start.ToLocalTime(),
                    End = appt.End.ToLocalTime()
                });
            });
            var appointmentBinding = new BindingSource();
            appointmentBinding.DataSource = displayAppt;
            reportTable.DataSource = appointmentBinding;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            weekRadio.Checked = false;
            monthRadio.Checked = true;
            await GetReport();
        }

        private async void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            weekRadio.Checked = true;
            monthRadio.Checked = false;
            await GetReport();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await GetReport();
        }

        private void Translate()
        {
            Name = _translator.Translate("consultantSchedules");
            Text = _translator.Translate("consultantSchedules");
            pageHeader.Text = _translator.Translate("consultantSchedules");
            monthRadio.Text = _translator.Translate("month");
            weekRadio.Text = _translator.Translate("week");
            searchBtn.Text = _translator.Translate("search");
            closeBtn.Text = _translator.Translate("close");
        }
    }
}
