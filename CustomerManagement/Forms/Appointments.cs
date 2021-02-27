using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Appointments : Form
    {
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Translator _translator;
        private readonly Customer _customer;
        private List<Appointment> _appointments;

        public Appointments(Context context, Translator translator, IAppointmentRepository appointmentRepository, Customer customer = null)
        {
            InitializeComponent();
            _context = context;
            _appointmentRepository = appointmentRepository;
            _translator = translator;
            _customer = customer;

            GetAppointments().Wait();
            TranslatePage();
        }

        private async Task GetAppointments()
        {
            var now = DateTime.UtcNow;
            DateTime start;
            DateTime end;
            if (_customer != null) // If this is for viewing customers appointments then show all the upcoming appointments
            {
                start = DateTime.UtcNow;
                end = DateTime.MaxValue;
            }
            else if (monthRadio.Checked)
            {
                start = new DateTime(now.Year, now.Month, 1); // first day of the month
                end = start.AddMonths(1).AddDays(-1); // last day of month
            }
            else
            {
                start = now.AddDays(-(int)now.DayOfWeek); // first day of the week
                end = start.AddDays(7); // last day of the week
            }
            _appointments = await _appointmentRepository.GetAllAsync(start, end, _context.CurrentUser.Id, _customer?.Id);

            SetTable(_appointments);
        }

        private void SetTable(List<Appointment> appointments)
        {
            if (appointments == null) return;

            if (_customer != null) // because we show all the customers appointments we don't need the filters
            {
                monthRadio.Visible = false;
                weekRadio.Visible = false;
            }

            // Map appointments to the table
            var displayAppt = new BindingList<object>();
            // Foreach is used to iterate over the entire appointments list
            appointments.ForEach(appt =>
            {
                displayAppt.Add(new
                {
                    appt.Id,
                    appt.Title,
                    appt.Type,
                    appt.Description,
                    appt.Contact,
                    appt.Location,
                    appt.Url,
                    Start = appt.Start.ToLocalTime(),
                    End = appt.End.ToLocalTime()
                });
            });
            var appointmentBinding = new BindingSource();
            appointmentBinding.DataSource = displayAppt;
            appointmentTable.DataSource = appointmentBinding;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var modifyAppt = new ModifyAppointment(_context, null, _customer);
            modifyAppt.Show();
            // refreshes the appointment data after the modify form is closed
            modifyAppt.FormClosed += async (object s, FormClosedEventArgs ec) =>
            {
                await GetAppointments();
            };
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var appointmentId = (int)appointmentTable.CurrentRow.Cells["Id"].Value;
            // find is used to get the appointment by id from the appointments list. If its not found it returns null
            var appointment = _appointments.Find(appt => appt.Id == appointmentId);
            if (appointment == null)
            {
                MessageBox.Show(_translator.Translate("appointment.noneSelected"));
                return;
            }
            var modifyAppt = new ModifyAppointment(_context, appointment, _customer);
            modifyAppt.Show();
            // refresh the appointment data
            modifyAppt.FormClosed += async (object s, FormClosedEventArgs ec) =>
            {
                await GetAppointments();
            };
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var appointmentId = (int)appointmentTable.CurrentRow.Cells["Id"].Value;
            var title = appointmentTable.CurrentRow.Cells["Title"].Value.ToString();

            var dialogResult = MessageBox.Show(_translator.Translate("appointment.confirmDelete", new { title }), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            try
            {
                await _appointmentRepository.DeleteAsync(appointmentId);
                await GetAppointments();
            }
            catch (Exception)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TranslatePage()
        {
            if (_customer != null)
            {
                pageHeader.Text = _translator.Translate("appointments.pageHeader", new { _customer.Name });
                Name = _translator.Translate("appointments.pageTitle");
                Text = _translator.Translate("appointments.pageTitle");
            }
            else
            {
                pageHeader.Text = _translator.Translate("calendar.pageHeader", new { _context.CurrentUser.Name });
                Name = _translator.Translate("calendar.pageTitle");
                Text = _translator.Translate("calendar.pageTitle");
            }
            monthRadio.Text = _translator.Translate("month");
            weekRadio.Text = _translator.Translate("week");
            addBtn.Text = _translator.Translate("add");
            editBtn.Text = _translator.Translate("edit");
            deleteBtn.Text = _translator.Translate("delete");
            closeBtn.Text = _translator.Translate("close");
        }

        private async void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            weekRadio.Checked = false;
            monthRadio.Checked = true;
            await GetAppointments();
        }

        private async void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            weekRadio.Checked = true;
            monthRadio.Checked = false;
            await GetAppointments();
        }
    }
}
