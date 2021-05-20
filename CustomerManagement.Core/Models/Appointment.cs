using CustomerManagement.Core.Attributes;
using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Core.Models
{
    public class Appointment : EntityBase, ITableItem
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
        [Column("customerName")]
        public string CustomerName { get; set; }
        [Column("customerPhone")]
        public string CustomerPhone { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            return new Dictionary<string, string>()
            {
                { "title", translation.Invoke("title") },
                { "start", translation.Invoke("start") },
                { "end", translation.Invoke("end") },
                { "customer", translation.Invoke("customer") },
                { "phone", translation.Invoke("phone") },
                { "type", translation.Invoke("type") },
                { "description", translation.Invoke("description") },
                { "crew", translation.Invoke("crew") },
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                Title,
                Start,
                End,
                CustomerName,
                CustomerPhone,
                Type,
                Description,
                Crew
            };
        }
    }
}
