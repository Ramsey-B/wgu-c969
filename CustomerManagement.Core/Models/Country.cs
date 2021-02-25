using CustomerManagement.Core.Attributes;

namespace CustomerManagement.Core.Models
{
    public class Country : EntityBase
    {
        [Column("country")]
        public string Name { get; set; }
        [Column("countryId")]
        public override int Id { get; set; }
    }
}
