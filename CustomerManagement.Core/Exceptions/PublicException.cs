using System;

namespace CustomerManagement.Core.Exceptions
{
    public class PublicException : Exception
    {
        public string Id { get; set; }
        public PublicException(string id, string msg = "") : base(msg)
        {
            Id = id;
        }
    }
}
