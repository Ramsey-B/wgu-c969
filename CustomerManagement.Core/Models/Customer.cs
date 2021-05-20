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
        [Column("address1")]
        public string Address1 { get; set; }
        [Column("address2")]
        public string Address2 { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("cityName")]
        public string City { get; set; }
        [Column("countryName")]
        public string Country { get; set; }
        [Column("postalCode")]
        public string PostalCode { get; set; }
        [Column("cityId")]
        public int CityId { get; set; }
        [Column("countryId")]
        public int CountryId { get; set; }

        public Dictionary<string, string> GetColumns(Func<string, string> translation)
        {
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
                Phone,
                Address1,
                Address2,
                City,
                PostalCode,
                Country
            };
        }
    }
}
