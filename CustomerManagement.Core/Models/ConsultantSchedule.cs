using CustomerManagement.Core.Attributes;
using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class ConsultantSchedule : ITableItem
    {

        [Column("customerName")]
        public string Customer { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("crewName")]
        public string Crew { get; set; }
        [Column("start")]
        public DateTime Start { get; set; }
        [Column("end")]
        public DateTime End { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            return new Dictionary<string, string>()
            {
                { "crew", translation.Invoke("crew") },
                { "customer", translation.Invoke("customer") },
                { "title", translation.Invoke("title") },
                { "start", translation.Invoke("start") },
                { "end", translation.Invoke("end") },
                { "type", translation.Invoke("type") },
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                Crew,
                Customer,
                Title,
                Start.ToLocalTime(),
                End.ToLocalTime(),
                Type,
            };
        }
    }
}
