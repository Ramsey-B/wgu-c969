using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class ConsultantSchedulesViewModel
    {
        private readonly IContext _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITranslator _translator;

        public ConsultantSchedulesViewModel(IContext context)
        {
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
            _translator = _context.GetService<ITranslator>();
        }

        public async Task<List<string>> GetCrewNames()
        {
            var now = DateTime.UtcNow;
            var start = new DateTime(now.Year, now.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);
            var appointments = await _appointmentRepository.GetAllAsync(start, end);
            return appointments.Select(a => a.Crew).OrderBy(c => c).ToList();
        }

        public async Task<List<ConsultantSchedule>> GetReport(string selectedCrew, bool day, bool week)
        {
            var now = DateTime.Today;
            DateTime start;
            DateTime end;
            if (day)
            {
                start = now; // start of day
                end = now.AddDays(1).AddSeconds(-1); // end of day
            }
            else if (week)
            {
                start = now.AddDays(-(int)now.DayOfWeek); // first day of the week
                end = start.AddDays(7); // last day of the week
            }
            else
            {
                start = new DateTime(now.Year, now.Month, 1); // first day of the month
                end = start.AddMonths(1).AddDays(-1); // last day of month
            }
            var crew = string.IsNullOrWhiteSpace(selectedCrew) || selectedCrew == _translator.Translate("all") ? null : selectedCrew;
            return await _appointmentRepository.GetConsultantSchedules(start, end, crew) ?? new List<ConsultantSchedule>();
        }
    }
}
