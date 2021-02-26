using System;

namespace CustomerManagement.Core.Exceptions
{
    /// <summary>
    /// Exception that indicates that the log in failed
    /// </summary>
    public class InvalidLoginException : Exception
    {
        // Failed username
        public string Username { get; set; }

        public InvalidLoginException(string username)
        {
            Username = username;
        }
    }
}
