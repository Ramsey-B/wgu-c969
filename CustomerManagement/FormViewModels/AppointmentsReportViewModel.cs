using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.FormViewModels
{
    public class AppointmentsReportViewModel
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITranslator _translator;
        private readonly IContext _context;

        public AppointmentsReportViewModel(IContext context)
        {
            _appointmentRepository = context.GetService<IAppointmentRepository>();
            _translator = context.GetService<ITranslator>();
            _context = context;
        }

        public async Task<List<AppointmentReport>> GetAppointmentReports(int yearSelected)
        {
            var startDate = new DateTime(yearSelected, 1, 1);
            var endDate = startDate.AddYears(1).AddDays(-1);
            var result = await _appointmentRepository.GetAllAsync(startDate, endDate, _context.CurrentUser.Id);

            var monthCount = new Dictionary<string, int>()
            {
                { "1", 0 }, // Jan
                { "2", 0 }, // Feb
                { "3", 0 }, // Mar
                { "4", 0 }, // April
                { "5", 0 }, // May
                { "6", 0 }, // June
                { "7", 0 }, // July
                { "8", 0 }, // Aug
                { "9", 0 }, // Sep
                { "10", 0 }, // Oct
                { "11", 0 }, // Nov
                { "12", 0 }, // Dec
            };
            result.ForEach(r =>
            {
                monthCount[r.Start.Month.ToString()]++;
            });
            var report = new List<AppointmentReport>();
            foreach (var month in monthCount)
            {
                report.Add(new AppointmentReport() { Month = _translator.Translate($"months.{month.Key}"), Count = month.Value });
            }
            return report;
        }
    }
}
