using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync(int userId, int? customerId, DateTime? start = null, DateTime? end = null);
        Task<int> CreateAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
        Task<int> DeleteAsync(int id);
    }
}
