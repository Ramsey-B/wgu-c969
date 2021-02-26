using System;

namespace CustomerManagement.Core.Exceptions
{
    /// <summary>
    /// Exception that indicates an appointment already exists that the requested time.
    /// </summary>
    public class OverlappingAppointmentException : Exception
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public OverlappingAppointmentException(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}
