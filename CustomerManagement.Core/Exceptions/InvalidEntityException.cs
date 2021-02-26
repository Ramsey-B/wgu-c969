using System;

namespace CustomerManagement.Core.Exceptions
{
    /// <summary>
    /// Exception the indicates an invalid entity
    /// </summary>
    public class InvalidEntityException : Exception
    {
        // Property that failed validation.
        public string PropertyName { get; set; }

        public InvalidEntityException(string propName)
        {
            PropertyName = propName;
        }
    }
}
