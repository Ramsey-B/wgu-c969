using CustomerManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class CustomerReport
    {
        [Column("customerId")]
        public int Id { get; set; }
        [Column("customerName")]
        public string CustomerName { get; set; }
        [Column("start")]
        public DateTime? LastAppointment { get; set; }
        public DateTime? NextAppointment { get; set; }
        public int AppointmentCount { get; set; }
    }
}
