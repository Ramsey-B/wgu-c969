using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public int Active { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
