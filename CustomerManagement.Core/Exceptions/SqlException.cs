using System;

namespace CustomerManagement.Core.Exceptions
{
    /// <summary>
    /// Exception thats throw when the sql ORM unexpectedly fails.
    /// </summary>
    public class SqlException : Exception
    {

        public SqlException(string msg) : base(msg)
        {

        }

        public SqlException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
