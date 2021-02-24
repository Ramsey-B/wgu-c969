using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Appointments : Form
    {
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ModifyAppointment _modifyAppointment;
        private readonly Translator _translator;
        private BindingList<Appointment> appointments;

        public Customer Customer { get; set; }

        public Appointments(Context context, Translator translator, IAppointmentRepository appointmentRepository, ModifyAppointment modifyAppointment)
        {
            InitializeComponent();
            _context = context;
            _appointmentRepository = appointmentRepository;
            _modifyAppointment = modifyAppointment;
            _translator = translator;

            Shown += async (object sender, EventArgs e) =>
            {
                await GetAppointments();
            };
        }

        private async Task GetAppointments()
        {
            var result = await _appointmentRepository.GetByCustomerIdAsync(_context.CurrentUser.Id, Customer.Id);
            appointments = new BindingList<Appointment>(result);
            var appointmentBinding = new BindingSource();
            appointmentBinding.DataSource = appointments;
            appointmentTable.DataSource = appointmentBinding;
            appointmentTable.Columns["UserId"].Visible = false;
            appointmentTable.Columns["CustomerId"].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            _modifyAppointment.Customer = Customer;
            _modifyAppointment.Appointment = null;
            _modifyAppointment.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var appointment = appointmentTable.CurrentRow.DataBoundItem as Appointment;
            if (appointment == null)
            {
                MessageBox.Show(_translator.Translate("appointment.noneSelected"));
                return;
            }
            _modifyAppointment.Customer = Customer;
            _modifyAppointment.Appointment = appointment;
            _modifyAppointment.Refresh();
            _modifyAppointment.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Hide(); // Call hide because we don't want to dispose of the form.
        }
    }
}
