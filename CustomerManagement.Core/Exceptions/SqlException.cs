using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
    public class SqlException : Exception
    {

        public SqlException(string msg) : base(msg)
        {

        }
    }
}
