using CustomerManagement.Core.Attributes;

namespace CustomerManagement.Core.Models
{
    public class Customer : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
