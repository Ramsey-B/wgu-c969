using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public string Username { get; set; }

        public InvalidLoginException(string username)
        {
            Username = username;
        }
    }
}
