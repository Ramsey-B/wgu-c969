using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
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
        private readonly Customer _customer;
        private BindingList<Appointment> appointments;

        public Appointments(Context context, Customer customer)
        {
            InitializeComponent();
            _context = context;
            _appointmentRepository = context.GetService<IAppointmentRepository>();
            _customer = customer;

            Shown += async (object sender, EventArgs e) =>
            {
                await GetAppointments();
            };
        }

        private async Task GetAppointments()
        {
            var result = await _appointmentRepository.GetByCustomerIdAsync(_context.CurrentUser.Id, _customer.Id);
            appointments = new BindingList<Appointment>(result);
            var appointmentBinding = new BindingSource();
            appointmentBinding.DataSource = appointments;
            appointmentTable.DataSource = appointmentBinding;
            appointmentTable.Columns["UserId"].Visible = false;
            appointmentTable.Columns["CustomerId"].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
