using System;
using System.IO;

namespace CustomerManagement.Logging
{
    public class Logger
    {
        // path to /bin/Debug/Logging/logs.txt or /bin/Release/Logging/logs.txt 
        private readonly string logPath = Directory.GetCurrentDirectory() + "\\Logging\\logs.txt";

        public void LogMessage(string message)
        {
            message = $"{DateTime.UtcNow} :: " + message + Environment.NewLine; // appends the datetime and new line char to the message
            File.AppendAllText(logPath, message); // append the line to the file
        }
    }
}
