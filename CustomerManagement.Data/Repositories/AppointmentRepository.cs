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

        public async Task<List<Appointment>> GetAllAsync(DateTime start, DateTime end, int? userId = null, int? customerId = null, string searchTerm = null)
        {
            var sql = SelectSql.Appointment;

            if (customerId != null)
            {
                sql += " AND appointment.customerId = @CustomerId@";
            }
            if (userId != null)
            {
                sql += " AND appointment.userId = @UserId@";
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                sql += $" AND (userName LIKE '%{searchTerm}%' OR type LIKE '%{searchTerm}%' OR customerName LIKE '%{searchTerm}%')";
            }

            return await _sqlOrm.QueryListAsync<Appointment>(sql, new { UserId = userId, CustomerId = customerId, Start = start, End = end });
        }

        public async Task<int> CreateAsync(Appointment appointment)
        {
            appointment.CreatedDate = DateTime.UtcNow;
            appointment.LastUpdated = DateTime.UtcNow;

            // Remove Seconds from schedule
            appointment.Start = new DateTime(appointment.Start.Year, appointment.Start.Month, appointment.Start.Day, appointment.Start.Hour, appointment.Start.Minute, 0);
            appointment.End = new DateTime(appointment.End.Year, appointment.End.Month, appointment.End.Day, appointment.End.Hour, appointment.End.Minute, 0);
            await AppointmentValidation(appointment);
            return await _sqlOrm.CreateEntityAsync(CreateSql.Appointment, appointment);
        }

        public async Task<int> UpdateAsync(Appointment appointment)
        {
            appointment.LastUpdated = DateTime.UtcNow;

            // Remove Seconds from schedule
            appointment.Start = new DateTime(appointment.Start.Year, appointment.Start.Month, appointment.Start.Day, appointment.Start.Hour, appointment.Start.Minute, 0);
            appointment.End = new DateTime(appointment.End.Year, appointment.End.Month, appointment.End.Day, appointment.End.Hour, appointment.End.Minute, 0);
            await AppointmentValidation(appointment);
            await _sqlOrm.ExecuteAsync(UpdateSql.Appointment, appointment);
            return 1;
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
            if (string.IsNullOrWhiteSpace(appointment.Title))
            {
                throw new InvalidEntityException("title");
            }

            if (string.IsNullOrWhiteSpace(appointment.Type))
            {
                throw new InvalidEntityException("type");
            }

            await AppointmentTimeCheckAsync(appointment.UserId, appointment.Start, appointment.End);
        }
    }
}
