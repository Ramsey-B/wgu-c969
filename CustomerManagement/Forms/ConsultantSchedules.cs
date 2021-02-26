using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class ConsultantSchedules : Form
    {
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;

        public ConsultantSchedules(Context context)
        {
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
            InitializeComponent();
            Init();
        }

        private async Task Init()
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

            results = results.OrderBy(appt => appt.Username).ToList();

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
            await Init();
        }

        private async void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            weekRadio.Checked = true;
            monthRadio.Checked = false;
            await Init();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await Init();
        }
    }
}
