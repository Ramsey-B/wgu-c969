using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class ModifyAppointmentViewModel
    {
        private readonly ITranslator _translator;
        public ModifyAppointmentViewModel(IContext context)
        {
            _translator = context.GetService<ITranslator>();
        }

        /// <summary>
        /// Validates the business hours of the new appointment,
        /// handles callback/validation errors, calls the callback 
        /// func with the new appointment.
        /// </summary>
        public async Task SubmitAsync(Appointment appointment, Func<Appointment, Task<int>> callback)
        {
            try
            {
                ValidateBusinessHours(appointment.Start, appointment.End);
                appointment.Start = appointment.Start.ToUniversalTime();
                appointment.End = appointment.End.ToUniversalTime();
                await callback(appointment);
            }
            catch (InvalidEntityException ex)
            {
                throw new PublicException("required-field-error", _translator.Translate("appointment.requiredFieldError", new { ex.PropertyName }));
            }
            catch (OverlappingAppointmentException ex)
            {
                var start = ex.Start.ToLocalTime();
                var end = ex.End.ToLocalTime();
                throw new PublicException("overlapping-appointment", _translator.Translate("appointment.overlappingAppointmentError", new { Start = start, End = end }));
            }
            catch (PublicException)
            {
                throw;
            }
            // catch all unexpected exceptions
            catch (Exception)
            {
                throw new PublicException("unexpected-error", _translator.Translate("unexpectedError"));
            }
        }


        private void ValidateBusinessHours(DateTime start, DateTime end)
        {
            var businessStart = DateTime.Today.ToLocalTime().AddHours(8);
            var businessEnd = DateTime.Today.ToLocalTime().AddHours(17);

            if (
                    start.Hour < businessStart.Hour || // before open
                    end.Hour > businessEnd.Hour || // after close
                    start < DateTime.Now.ToLocalTime() || // Date is in the past
                    start.Year != end.Year || // different years
                    start.Month != end.Month || // different months
                    start.Day != end.Day || // different days
                    start >= end // start is after end
                )
            {
                throw new PublicException("out-of-business-hours", _translator.Translate("appointment.outOfHoursError", new { Open = businessStart, Close = businessEnd }));
            }
        }
    }
}
