using System;
using System.IO;

namespace CustomerManagement.Logging
{
    public class Logger
    {
        // path to /bin/Debug/logs.txt or /bin/Release/logs.txt 
        private readonly string logPath = Directory.GetCurrentDirectory() + "\\logs.txt";

        public void LogMessage(string message)
        {
            message = $"{DateTime.UtcNow} :: " + message + Environment.NewLine; // appends the datetime and new line char to the message
            File.AppendAllText(logPath, message); // append the line to the file
        }
    }
}
