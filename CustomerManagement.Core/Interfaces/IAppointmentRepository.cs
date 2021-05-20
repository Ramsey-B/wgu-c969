using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync(DateTime start, DateTime end, int? userId = null, int? customerId = null, string searchTerm = null);
        Task<List<ConsultantSchedule>> GetConsultantSchedules(DateTime start, DateTime end, string crewName = "");
        Task<int> CreateAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
        Task<int> DeleteAsync(int id);
    }
}
