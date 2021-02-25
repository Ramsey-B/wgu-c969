using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (_appointment == null)
            {
                Name = _translator.Translate("appointment.addAppointment");
                Text = _translator.Translate("appointment.addAppointment");
            }
            else
            {
                Name = _translator.Translate("appointment.editAppointment");
                Text = _translator.Translate("appointment.editAppointment");
            }

            if (_customer == null)
            {
                pageTitle.Text = _translator.Translate("appointment.modifyTitleNoCustomer");
            }
            else
            {
                pageTitle.Text = _translator.Translate("appointment.modifyTitle", new { _customer.Name });
            }
            descriptionLabel.Text = _translator.Translate("appointment.description");
            locationLabel.Text = _translator.Translate("appointment.location");
            contactLabel.Text = _translator.Translate("appointment.contact");
            typeLabel.Text = _translator.Translate("appointment.type");
            urlLabel.Text = _translator.Translate("appointment.url");
            startLabel.Text = _translator.Translate("appointment.start");
            endLabel.Text = _translator.Translate("appointment.end");
            cancelBtn.Text = _translator.Translate("cancel");
            submitBtn.Text = _translator.Translate("submit");
        }

        private void Init()
        {
            if (_appointment != null)
            {
                titleInput.Text = _appointment.Title;
                descriptionInput.Text = _appointment.Description;
                locationInput.Text = _appointment.Location;
                contactInput.Text = _appointment.Contact;
                typeInput.Text = _appointment.Type;
                urlInput.Text = _appointment.Url;
                startInput.Value = _appointment.Start.ToLocalTime();
                endInput.Value = _appointment.End.ToLocalTime();
            }
        }

        private void ValidateBusinessHours()
        {
            var businessStart = DateTime.Today.ToLocalTime().AddHours(8);
            var businessEnd = DateTime.Today.ToLocalTime().AddHours(17);

            if (
                    startInput.Value < businessStart || // before open
                    endInput.Value > businessEnd || // after close
                    startInput.Value >= endInput.Value // start is after end
                )
            {
                throw new OutOfHoursException(businessStart, businessEnd);
            }
        }

        private async Task SubmitAsync(Appointment appointment, Func<Appointment, Task<int>> callback)
        {
            try
            {
                ValidateBusinessHours();
                await callback(appointment);
                Close();
            }
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
            catch (Exception)
            {
                errorLabel.Visible = true;
                errorLabel.Text = _translator.Translate("unexpectedError");
            }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            if (_customer == null)
            {
                errorLabel.Text = _translator.Translate("appointments.noCustomerSelected");
                errorLabel.Visible = true;
                return;
            }
            if (_appointment == null)
            {
                var newAppt = new Appointment
                {
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Contact = contactInput.Text,
                    Type = typeInput.Text,
                    Url = urlInput.Text,
                    Start = startInput.Value.ToUniversalTime(),
                    End = endInput.Value.ToUniversalTime(),
                    CreatedBy = _context.CurrentUser.Name,
                    LastUpdateBy = _context.CurrentUser.Name
                };

                await SubmitAsync(newAppt, _appointmentRepository.CreateAsync);
            }
            else
            {
                var newAppt = new Appointment
                {
                    CustomerId = _customer.Id,
                    UserId = _context.CurrentUser.Id,
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    Location = locationInput.Text,
                    Contact = contactInput.Text,
                    Type = typeInput.Text,
                    Url = urlInput.Text,
                    Start = startInput.Value.ToUniversalTime(),
                    End = endInput.Value.ToUniversalTime(),
                    LastUpdateBy = _context.CurrentUser.Name
                };

                await SubmitAsync(newAppt, _appointmentRepository.UpdateAsync);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customerSelect_Click(object sender, EventArgs e)
        {
            var select = new CustomerSelect(_context);
            select.ShowDialog();
            select.FormClosing += (object s, FormClosingEventArgs ec) =>
            {
                if (select.Customer != null)
                {
                    _customer = select.Customer;
                }
            };
        }
    }
}
