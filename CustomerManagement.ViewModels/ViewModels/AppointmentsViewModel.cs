using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class AppointmentsViewModel
    {
        private readonly IContext _context;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsViewModel(IContext context)
        {
            _context = context;
            _appointmentRepository = _context.GetService<IAppointmentRepository>();
        }

        public async Task<List<Appointment>> GetAppointments(string searchTerm, Customer customer, bool day, bool week)
        {
            var now = DateTime.Today;
            DateTime start;
            DateTime end;
            if (customer != null) // If this is for viewing customers appointments then show all the upcoming appointments
            {
                start = now;
                end = DateTime.MaxValue;
            }
            else if (day)
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
            return await _appointmentRepository.GetAllAsync(start, end, _context.CurrentUser.Id, customer?.Id, searchTerm);
        }
    }
}
