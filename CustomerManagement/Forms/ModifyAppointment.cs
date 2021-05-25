using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.ViewModels;
using CustomerManagement.Translations;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class ModifyAppointment : Form
    {
        private readonly ITranslator _translator;
        private readonly IContext _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private Customer _customer;
        private readonly ModifyAppointmentViewModel _viewModel;
        private readonly Appointment _appointment;
        public ModifyAppointment(IContext context, Appointment appointment = null, Customer customer = null)
        {
            _translator = context.GetService<ITranslator>();
            _context = context;
            _appointmentRepository = context.GetService<IAppointmentRepository>();
            _appointment = appointment;
            _customer = customer;
            _viewModel = new ModifyAppointmentViewModel(context);
            InitializeComponent();
            TranslatePage();
            Init();
        }

        private void TranslatePage()
        {
            if (_appointment == null) // if appointment is null then we're creating a new one
            {
                Name = _translator.Translate("appointment.addAppointment");
                Text = _translator.Translate("appointment.addAppointment");
            }
            else // else we're editing the new one
            {
                Name = _translator.Translate("appointment.editAppointment");
                Text = _translator.Translate("appointment.editAppointment");
            }

            if (_customer == null) // if no customer is provided we need the user to select one
            {
                pageTitle.Text = _translator.Translate("appointment.modifyTitleNoCustomer");
            }
            else
            {
                pageTitle.Text = _translator.Translate("appointment.modifyTitle", new { _customer.Name });
            }
            descriptionLabel.Text = _translator.Translate("appointment.description");
            locationLabel.Text = _translator.Translate("appointment.location");
            crewLabel.Text = _translator.Translate("appointment.crew");
            typeLabel.Text = _translator.Translate("appointment.type");
            startLabel.Text = _translator.Translate("appointment.start");
            endLabel.Text = _translator.Translate("appointment.end");
            cancelBtn.Text = _translator.Translate("cancel");
            submitBtn.Text = _translator.Translate("submit");
        }

        private void Init()
        {
            if (_appointment != null) // if we're editing an appointment then set the inputs to their existing values.
            {
                titleInput.Text = _appointment.Title;
                descriptionInput.Text = _appointment.Description;
                locationInput.Text = _appointment.Location;
                crewInput.Text = _appointment.Crew;
                typeInput.Text = _appointment.Type;
                startInput.Value = _appointment.Start.ToLocalTime();
                endInput.Value = _appointment.End.ToLocalTime();
            }
            else
            {
                if (DateTime.Now.ToLocalTime().Hour < 8)
                {
                    startInput.MinDate = DateTime.Today.AddHours(8);
                    endInput.MinDate = DateTime.Today.AddMinutes(1);
                    endInput.MaxDate = DateTime.Today.AddHours(17);
                }
                else if (DateTime.Now.ToLocalTime().Hour >= 17)
                {
                    startInput.MinDate = DateTime.Today.AddDays(1).AddHours(8);
                    endInput.MinDate = DateTime.Today.AddDays(1).AddHours(8).AddMinutes(1);
                    endInput.MaxDate = DateTime.Today.AddDays(1).AddHours(17);
                }
                else
                {
                    startInput.MinDate = DateTime.Now.ToLocalTime();
                    endInput.MinDate = DateTime.Now.ToLocalTime().AddMinutes(1);
                    endInput.MaxDate = DateTime.Today.AddHours(17);
                }
            }

            startInput.ValueChanged += (object sender, EventArgs e) =>
            {
                Debounce(() =>
                {
                    var start = startInput.Value;
                    if (start.Hour < 8)
                    {
                        startInput.Value = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                    }
                    if (start.Hour >= 17)
                    {
                        startInput.Value = new DateTime(start.Year, start.Month, start.Day, 16, 58, 0);
                    }
                    start = startInput.Value;

                    // set end min/max
                    endInput.MinDate = DateTime.Now;
                    endInput.MaxDate = DateTime.Now.AddMinutes(1);
                    endInput.MaxDate = new DateTime(start.Year, start.Month, start.Day).AddHours(17);
                    endInput.MinDate = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute + 1, start.Second);
                });
            };
        }
        private static DateTime lastCall = DateTime.MinValue;
        private void Debounce(Action action)
        {
            if (lastCall < DateTime.UtcNow.AddMilliseconds(-300))
            {
                action.Invoke();
            }
            lastCall = DateTime.UtcNow;
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            if (_customer == null) // ensure that a customer has been selected.
            {
                errorLabel.Text = _translator.Translate("appointments.noCustomerSelected");
                errorLabel.Visible = true;
                return;
            }
            Func<Appointment, Task<int>> callback;
            Appointment newAppt;
            if (_appointment == null) // create a new appointment
            {
                newAppt = new Appointment
                {
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Crew = crewInput.Text,
                    Type = typeInput.Text,
                    Start = startInput.Value,
                    End = endInput.Value,
                    CreatedBy = _context.CurrentUser.Username,
                    LastUpdatedBy = _context.CurrentUser.Username
                };

                callback = _appointmentRepository.CreateAsync;
            }
            else // edit an existing appointment
            {
                newAppt = new Appointment
                {
                    Id = _appointment.Id,
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Crew = crewInput.Text,
                    Type = typeInput.Text,
                    Start = startInput.Value.ToLocalTime(),
                    End = endInput.Value.ToLocalTime(),
                    LastUpdatedBy = _context.CurrentUser.Username
                };

                callback = _appointmentRepository.UpdateAsync;
            }

            try
            {
                await _viewModel.SubmitAsync(newAppt, callback);
                Close();
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customerSelect_Click(object sender, EventArgs e)
        {
            var select = new CustomerSelect(_context);
            select.Show();

            // Adds the lambda to the FormClosing life cycle events to that we can grab the selected customer 
            // before the form closes. A lambda is used because this code is not reused.
            select.FormClosing += (object s, FormClosingEventArgs ec) =>
            {
                if (select.Customer != null) // only set and update the title if the user selected a customer
                {
                    _customer = select.Customer;
                    pageTitle.Text = _translator.Translate("appointment.modifyTitle", new { _customer.Name });
                }
            };
        }
    }
}
