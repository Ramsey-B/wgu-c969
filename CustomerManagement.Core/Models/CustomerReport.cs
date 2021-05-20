using CustomerManagement.Core.Attributes;
using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class CustomerReport : ITableItem
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string CustomerName { get; set; }
        [Column("start")]
        public DateTime? LastAppointment { get; set; }
        public DateTime? NextAppointment { get; set; }
        public int AppointmentCount { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            return new Dictionary<string, string>()
            {
                { "customer", translation.Invoke("customer") },
                { "lastAppointment", translation.Invoke("lastAppointment") },
                { "nextAppointment", translation.Invoke("nextAppointment") },
                { "appointmentCount", translation.Invoke("appointmentCount") },
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                CustomerName,
                LastAppointment?.ToLocalTime(),
                NextAppointment?.ToLocalTime(),
                AppointmentCount
            };
        }
    }
}
