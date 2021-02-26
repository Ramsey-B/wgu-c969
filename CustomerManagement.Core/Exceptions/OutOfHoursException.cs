using System;

namespace CustomerManagement.Core.Exceptions
{
    /// <summary>
    /// Exception that indicates an appointment has invalid hours
    /// </summary>
    public class OutOfHoursException : Exception
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }

        public OutOfHoursException(DateTime open, DateTime close)
        {
            Open = open;
            Close = close;
        }
    }
}
