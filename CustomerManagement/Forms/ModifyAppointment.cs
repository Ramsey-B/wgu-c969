using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class ModifyAppointment : Form
    {
        private readonly Translator _translator;
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private Customer _customer;
        private readonly Appointment _appointment;
        public ModifyAppointment(Context context, Appointment appointment = null, Customer customer = null)
        {
            _translator = context.GetService<Translator>();
            _context = context;
            _appointmentRepository = context.GetService<IAppointmentRepository>();
            _appointment = appointment;
            _customer = customer;
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
            crewLabel.Text = _translator.Translate("appointment.contact");
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
        }

        private void ValidateBusinessHours()
        {
            var businessStart = DateTime.Today.ToLocalTime().AddHours(8);
            var businessEnd = DateTime.Today.ToLocalTime().AddHours(17);

            if (
                    startInput.Value.Hour < businessStart.Hour || // before open
                    endInput.Value.Hour > businessEnd.Hour || // after close
                    startInput.Value < DateTime.Now.ToLocalTime() || // Date is in the past
                    startInput.Value.Year != endInput.Value.Year || // different years
                    startInput.Value.Day != endInput.Value.Day || // different days
                    startInput.Value >= endInput.Value // start is after end
                )
            {
                throw new OutOfHoursException(businessStart, businessEnd);
            }
        }

        /// <summary>
        /// Validates the business hours of the new appointment,
        /// handles callback/validation errors, calls the callback 
        /// func with the new appointment.
        /// </summary>
        private async Task SubmitAsync(Appointment appointment, Func<Appointment, Task<int>> callback)
        {
            try
            {
                ValidateBusinessHours();
                await callback(appointment);
                Close(); // close the popup if the callback is successful
            }
            // catch specific errors
            catch (OutOfHoursException ex)
            {
                errorLabel.Visible = true;
                errorLabel.Text = _translator.Translate("appointment.outOfHoursError", new { ex.Open, ex.Close });
            }
            catch (InvalidEntityException ex)
            {
                errorLabel.Visible = true;
                errorLabel.Text = _translator.Translate("appointment.requiredFieldError", new { ex.PropertyName });
            }
            catch (OverlappingAppointmentException ex)
            {
                errorLabel.Visible = true;
                var start = ex.Start.ToLocalTime();
                var end = ex.End.ToLocalTime();
                errorLabel.Text = _translator.Translate("appointment.overlappingAppointmentError", new { Start = start, End = end });
            }
            // catch all unexpected exceptions
            catch (Exception)
            {
                errorLabel.Visible = true;
                errorLabel.Text = _translator.Translate("unexpectedError");
            }
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
            if (_appointment == null) // create a new appointment
            {
                var newAppt = new Appointment
                {
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Crew = crewInput.Text,
                    Type = typeInput.Text,
                    Start = startInput.Value.ToUniversalTime(),
                    End = endInput.Value.ToUniversalTime(),
                    CreatedBy = _context.CurrentUser.Username,
                    LastUpdatedBy = _context.CurrentUser.Username
                };

                await SubmitAsync(newAppt, _appointmentRepository.CreateAsync); // pass the create as the callback
            }
            else // edit an existing appointment
            {
                var newAppt = new Appointment
                {
                    Id = _appointment.Id,
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Crew = crewInput.Text,
                    Type = typeInput.Text,
                    Start = startInput.Value.ToUniversalTime(),
                    End = endInput.Value.ToUniversalTime(),
                    LastUpdatedBy = _context.CurrentUser.Username
                };

                await SubmitAsync(newAppt, _appointmentRepository.UpdateAsync); // pass the update as the callback
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
