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

        public async Task<List<Appointment>> GetAllAsync(int userId, int? customerId, DateTime? start = null, DateTime? end = null)
        {
            var sql = SelectSql.Appointment;

            if (customerId != null)
            {
                sql += " AND customerId = @CustomerId";
            }
            if (start != null)
            {
                sql += " AND start >= @Start";
            }
            if (end != null)
            {
                sql += " AND start <= @End";
            }

            return await _sqlOrm.QueryListAsync<Appointment>(sql, new { UserId = userId, CustomerId = customerId, Start = start, End = end });
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

        public async Task<int> DeleteAsync(int id)
        {
            return await _sqlOrm.DeleteAsync(id, "appointment");
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
