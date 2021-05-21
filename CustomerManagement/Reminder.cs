using CustomerManagement.Core.Interfaces;
using CustomerManagement.Translations;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Reminder
    {
        private readonly IContext _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITranslator _translator;

        public Reminder(IContext context)
        {
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>(); ;
            _translator = _context.GetService<ITranslator>();
        }

        /// <summary>
        /// Handles the display of appointment reminders within 15 minutes
        /// Do not await this method or execution of other code will be blocked.
        /// </summary>
        public async Task HandleAppointmentReminders()
        {
            // Get the appointments for the rest of the day
            var appointments = await _appointmentRepository.GetAllAsync(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow.AddDays(1), _context.CurrentUser.Id);
            appointments = appointments.OrderBy(appt => appt.Start).ToList(); // order the appointments by start to ensure reminder order.

            foreach (var appt in appointments)
            {
                var timeToGo = appt.Start - DateTime.UtcNow.AddMinutes(15); // time till the reminder must pop
                if (timeToGo.Ticks > 0) // The appointment is over 15 mins from now
                {
                    await Task.Delay(timeToGo); // delay the current task till the appointment is 15 mins out. As long as this func is not awaited this will not block the main thread.
                }
                MessageBox.Show(_translator.Translate("reminderMessage", new { Minutes = timeToGo.Minutes + 15, appt.CustomerName, Time = appt.Start.ToLocalTime() }));
            }
        }
    }
}
