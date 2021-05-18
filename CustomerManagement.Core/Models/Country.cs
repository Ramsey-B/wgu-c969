using CustomerManagement.Core.Attributes;

namespace CustomerManagement.Core.Models
{
    public class Country : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
