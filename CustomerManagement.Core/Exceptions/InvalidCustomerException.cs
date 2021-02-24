using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
    public class InvalidCustomerException : Exception
    {
        public string PropertyName { get; set; }

        public InvalidCustomerException(string propName)
        {
            PropertyName = propName;
        }
    }
}
