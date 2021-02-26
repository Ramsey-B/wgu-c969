using System;

namespace CustomerManagement.Core.Attributes
{
    /// <summary>
    /// With the customer ORM this value is used to map a DB column to the object properties
    /// </summary>
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
