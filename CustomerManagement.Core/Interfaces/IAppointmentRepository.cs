using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetByCustomerIdAsync(int userId, int customerId);
        Task<int> CreateAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
    }
}
