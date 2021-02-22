using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
    }
}
