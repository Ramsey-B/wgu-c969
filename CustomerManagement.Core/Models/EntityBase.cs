using CustomerManagement.Core.Attributes;
using System;

namespace CustomerManagement.Core.Models
{
    public abstract class EntityBase
    {
        public abstract int Id { get; set; }
        [Column("createDate")]
        public DateTime CreateDate { get; set; }
        [Column("createdBy")]
        public string CreatedBy { get; set; }
        [Column("lastUpdate")]
        public DateTime LastUpdate { get; set; }
        [Column("lastUpdateBy")]
        public string LastUpdateBy { get; set; }
    }
}
