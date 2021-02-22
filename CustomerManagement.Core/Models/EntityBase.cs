using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public abstract class EntityBase
    {
        public int? Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
