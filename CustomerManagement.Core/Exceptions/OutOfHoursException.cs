using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Core.Exceptions
{
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
