using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public string PropertyName { get; set; }

        public InvalidEntityException(string propName)
        {
            PropertyName = propName;
        }
    }
}
