using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public ColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
