using CustomerManagement.Core.Exceptions;
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
            appointment.CreateDate = DateTime.UtcNow;
            appointment.LastUpdate = DateTime.UtcNow;
            await AppointmentValidation(appointment);
            return await _sqlOrm.CreateEntityAsync(CreateSql.Appointment, appointment);
        }

        public async Task<int> UpdateAsync(Appointment appointment)
        {
            appointment.LastUpdate = DateTime.UtcNow;
            await AppointmentValidation(appointment);
            return await _sqlOrm.ExecuteAsync(UpdateSql.Appointment, appointment);
        }

        /// <summary>
        /// Validates the appointment timeslot
        /// </summary>
        private async Task AppointmentTimeCheckAsync(int userId, DateTime start, DateTime end)
        {
            var result = await _sqlOrm.QueryAsync<Appointment>(SelectSql.AppointmentTimeCheck, new { UserId = userId, Start = start, End = end });
            if (result != null)
            {
                throw new OverlappingAppointmentException(result.Start, result.End);
            }
        }

        private async Task AppointmentValidation(Appointment appointment)
        {
            await AppointmentTimeCheckAsync(appointment.UserId, appointment.Start, appointment.End);

            if (string.IsNullOrWhiteSpace(appointment.Title))
            {
                throw new InvalidEntityException("title");
            }

            if (string.IsNullOrWhiteSpace(appointment.Type))
            {
                throw new InvalidEntityException("type");
            }
        }
    }
}
