using CustomerManagement.Core.Attributes;

namespace CustomerManagement.Core.Models
{
    public class Address : EntityBase
    {
        [Column("addressId")]
        public override int Id { get; set; }
        [Column("address")]
        public string Address1 { get; set; }
        [Column("address2")]
        public string Address2 { get; set; }
        [Column("postalCode")]
        public string PostalCode { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("cityId")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
