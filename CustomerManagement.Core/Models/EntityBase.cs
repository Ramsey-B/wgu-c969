using CustomerManagement.Core.Attributes;
using System;

namespace CustomerManagement.Core.Models
{
    /// <summary>
    /// Base class for the common fields
    /// </summary>
    public class EntityBase
    {
        [Column("id")]
        public virtual int Id { get; set; }
        [Column("createdDate")]
        public virtual DateTime CreatedDate { get; set; }
        [Column("createdBy")]
        public virtual string CreatedBy { get; set; }
        [Column("lastUpdated")]
        public virtual DateTime LastUpdated { get; set; }
        [Column("lastUpdatedBy")]
        public virtual string LastUpdatedBy { get; set; }
    }
}
