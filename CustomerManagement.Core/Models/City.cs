using CustomerManagement.Core.Attributes;

namespace CustomerManagement.Core.Models
{
    public class City : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }
        public Country Country { get; set; }
        [Column("countryId")]
        public int CountryId { get; set; }
    }
}
