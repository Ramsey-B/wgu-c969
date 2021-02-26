using CustomerManagement.Core.Interfaces;
using CustomerManagement.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement
{
    public class Reminder
    {
        private readonly Context _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Translator _translator;

        public Reminder(Context context, IAppointmentRepository appointmentRepository, Translator translator)
        {
            _context = context;
            _appointmentRepository = appointmentRepository;
            _translator = translator;
        }

        public async Task HandleAppointmentReminders()
        {
            var appointments = await _appointmentRepository.GetAllAsync(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow.AddDays(1), _context.CurrentUser.Id);
            appointments = appointments.OrderBy(appt => appt.Start).ToList();

            foreach (var appt in appointments)
            {
                await Task.Run(async () =>
                {
                    var timeToGo = appt.Start - DateTime.UtcNow.AddMinutes(15);
                    if (timeToGo.Ticks > 0) // The appointment is over 15 mins from now
                    {
                        await Task.Delay(timeToGo);
                    }
                    MessageBox.Show(_translator.Translate("reminderMessage", new { Minutes = timeToGo.Minutes + 15, appt.CustomerName, Time = appt.Start.ToLocalTime() }));
                });
            }
        }
    }
}
