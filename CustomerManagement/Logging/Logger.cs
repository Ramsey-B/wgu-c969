using System;
using System.IO;

namespace CustomerManagement.Logging
{
    public class Logger
    {
        private readonly string logPath = Directory.GetCurrentDirectory() + "\\Logging\\logs.txt";

        public void LogMessage(string message)
        {
            message = $"{DateTime.UtcNow} :: " + message + Environment.NewLine;
            File.AppendAllText(logPath, message);
        }
    }
}
