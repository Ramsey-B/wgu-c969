using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class AppointmentReport : ITableItem
    {
        public string Month { get; set; }
        public int Count { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            return new Dictionary<string, string>()
            {
                { "month", translation.Invoke("month") },
                { "count", translation.Invoke("count") },
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                Month,
                Count
            };
        }
    }
}
