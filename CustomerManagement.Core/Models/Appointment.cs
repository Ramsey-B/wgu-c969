using CustomerManagement.Core.Attributes;
using System;

namespace CustomerManagement.Core.Models
{
    public class Appointment : EntityBase
    {
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
        [Column("crewName")]
        public string Crew { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("start")]
        public DateTime Start { get; set; }
        [Column("end")]
        public DateTime End { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("name")]
        public string CustomerName { get; set; }
    }
}
