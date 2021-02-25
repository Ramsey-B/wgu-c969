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

        public Appointments(Context context, Translator translator, IAppointmentRepository appointmentRepository, Customer customer = null)
        {
            InitializeComponent();
            _context = context;
            _appointmentRepository = appointmentRepository;
            _translator = translator;
            _customer = customer;

            Shown += async (object sender, EventArgs e) =>
            {
                await GetAppointments();
                TranslatePage();
            };
        }

        private async Task GetAppointments()
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
            var result = await _appointmentRepository.GetAllAsync(_context.CurrentUser.Id, _customer?.Id, start, end);

            SetTable(result);
        }

        private void SetTable(List<Appointment> appointments)
        {
            if (appointments == null) return;
            var displayAppt = new BindingList<object>();
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
            modifyAppt.FormClosed += async (object s, FormClosedEventArgs ec) =>
            {
                await GetAppointments();
            };
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var appointment = appointmentTable.CurrentRow.DataBoundItem as Appointment;
            if (appointment == null)
            {
                MessageBox.Show(_translator.Translate("appointment.noneSelected"));
                return;
            }
            var modifyAppt = new ModifyAppointment(_context, appointment, _customer);
            modifyAppt.Show();
            modifyAppt.FormClosed += async (object s, FormClosedEventArgs ec) =>
            {
                await GetAppointments();
            };
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var appointment = appointmentTable.CurrentRow.DataBoundItem as Appointment;
            if (appointment == null)
            {
                MessageBox.Show(_translator.Translate("appointment.noneSelected"));
                return;
            }
            var dialogResult = MessageBox.Show(_translator.Translate("appointment.confirmDelete", new { appointment.Title }), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            try
            {
                await _appointmentRepository.DeleteAsync(appointment.Id);
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
