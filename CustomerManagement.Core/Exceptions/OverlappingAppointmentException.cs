using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
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
