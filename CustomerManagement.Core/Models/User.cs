using CustomerManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Models
{
    public class User : EntityBase
    {
        [Column("userName")]
        public string Name { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("active")]
        public int Active { get; set; }
        [Column("userId")]
        public override int Id { get; set; }
    }
}
