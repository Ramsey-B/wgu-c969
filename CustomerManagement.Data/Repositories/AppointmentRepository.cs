using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ISqlOrm _sqlOrm;
        public AppointmentRepository(ISqlOrm sqlOrm)
        {
            _sqlOrm = sqlOrm;
        }

        public async Task<List<Appointment>> GetByCustomerIdAsync(int userId, int customerId)
        {
            return await _sqlOrm.QueryListAsync<Appointment>(SelectSql.Appointment, new { UserId = userId, CustomerId = customerId });
        }

        public async Task<int> CreateAsync(Appointment appointment)
        {
            return await _sqlOrm.CreateEntityAsync("appointment", CreateSql.Appointment, appointment, appointment);
        }

        public async Task<int> UpdateAsync(Appointment appointment)
        {
            appointment.LastUpdate = DateTime.UtcNow;
            return await _sqlOrm.ExecuteAsync(UpdateSql.Appointment, appointment);
        }
    }
}
