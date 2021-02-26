using CustomerManagement.Core.Attributes;
using System;

namespace CustomerManagement.Core.Models
{
    public class Appointment : EntityBase
    {
        [Column("appointmentId")]
        public override int Id { get; set; }
        [Column("customerId")]
        public int CustomerId { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("contact")]
        public string Contact { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("start")]
        public DateTime Start { get; set; }
        [Column("end")]
        public DateTime End { get; set; }
        [Column("userName")]
        public string Username { get; set; }
        [Column("customerName")]
        public string CustomerName { get; set; }
    }
}
