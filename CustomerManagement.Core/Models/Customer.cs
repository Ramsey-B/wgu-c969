using CustomerManagement.Core.Attributes;
using CustomerManagement.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Core.Models
{
    public class Customer : EntityBase, ITableItem
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
            if (translation == null)
            {
                translation = (string str) => str;
            }

            return new Dictionary<string, string>()
            {
                { "name", translation.Invoke("name") },
                { "active", translation.Invoke("active") },
                { "phone", translation.Invoke("phone") },
                { "address1", translation.Invoke("address1") },
                { "address2", translation.Invoke("address2") },
                { "city", translation.Invoke("city") },
                { "postalCode", translation.Invoke("postalCode") },
                { "country", translation.Invoke("country") },
            };
        }

        public object[] GetRow()
        {
            return new object[]
            {
                Name,
                Active,
                Address?.Phone,
                Address?.Address1,
                Address?.Address2,
                Address?.City?.Name,
                Address?.PostalCode,
                Address?.City?.Country?.Name
            };
        }
    }
}
