using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class CustomerSelect : ITableItem
    {
        public string Name { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            return new Dictionary<string, string>()
            {
                { "name", translation.Invoke("name") }
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                Name
            };
        }
    }
}
