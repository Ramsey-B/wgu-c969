using CustomerManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class User : EntityBase
    {
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("active")]
        public bool Active { get; set; }
    }
}
