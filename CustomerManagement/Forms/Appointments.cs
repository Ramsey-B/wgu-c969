using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Forms.Customers;
using CustomerManagement.Tables;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Appointments : Form
    {
        private readonly IContext _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Translator _translator;
        private readonly Customer _customer;
        private List<Appointment> _appointments;

        public Appointments(IContext context, Customer customer = null)
        {
            InitializeComponent();
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
            _translator = _context.GetService<Translator>();
            _customer = customer;

            _ = GetAppointments();
            TranslatePage();

            monthRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = false;
                monthRadio.Checked = true;
                await GetAppointments(searchInput.Text);
            };

            weekRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = false;
                weekRadio.Checked = true;
                monthRadio.Checked = false;
                await GetAppointments(searchInput.Text);
            };

            dayRadio.Click += async (object sender, EventArgs e) =>
            {
                dayRadio.Checked = true;
                weekRadio.Checked = false;
                monthRadio.Checked = false;
                await GetAppointments(searchInput.Text);
            };
        }

        private async Task GetAppointments(string searchTerm = "")
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
            _appointments = await _appointmentRepository.GetAllAsync(start, end, _context.CurrentUser.Id, _customer?.Id, searchTerm);

            SetTable(_appointments);
        }

        private void SetTable(List<Appointment> appointments)
        {
            if (appointments == null) return;

            if (_customer != null) // because we show all the customers appointments we don't need the filters
            {
                monthRadio.Visible = false;
                weekRadio.Visible = false;
                dayRadio.Visible = false;
            }

            TableService.SetData<Appointment>(ref appointmentTable, appointments, (string key) => _translator.Translate($"appointment.{key}"));
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
            var index = appointmentTable.CurrentRow.Index;
            // find is used to get the appointment by id from the appointments list. If its not found it returns null
            var appointment = _appointments[index];
            if (appointment == null)
            {
                MessageBox.Show(_translator.Translate("appointment.noneSelected"));
                return;
            }
            var modifyAppt = new ModifyAppointment(_context, appointment, new Customer 
            { 
                Id = appointment.CustomerId, 
                Name = appointment.CustomerName
            });
            modifyAppt.Show();
            // refresh the appointment data
            modifyAppt.FormClosed += async (object s, FormClosedEventArgs ec) =>
            {
                await GetAppointments();
            };
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var index = appointmentTable.CurrentRow.Index;
            var appointment = _appointments[index];

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
                pageHeader.Text = _translator.Translate("calendarPage.pageHeader", new { _context.CurrentUser.Username });
                Name = _translator.Translate("calendarPage.pageTitle");
                Text = _translator.Translate("calendarPage.pageTitle");
            }
            customersBtn.Text = _translator.Translate("customers");
            calendarBtn.Text = _translator.Translate("calendar");
            reportsBtn.Text = _translator.Translate("reports");
            exitBtn.Text = _translator.Translate("exit");
            monthRadio.Text = _translator.Translate("month");
            weekRadio.Text = _translator.Translate("week");
            dayRadio.Text = _translator.Translate("day");
            searchBtn.Text = _translator.Translate("search");
            addBtn.Text = _translator.Translate("add");
            editBtn.Text = _translator.Translate("edit");
            deleteBtn.Text = _translator.Translate("delete");
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard(_context);
            _context.Navigate(dashboard);
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await GetAppointments(searchInput.Text);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            var reports = new Reports(_context);
            _context.Navigate(reports);
        }
    }
}
