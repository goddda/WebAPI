using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure
{
    public class FileLogger : IMyLogger
    {
        /*
        private readonly IMyTime _time;
        public FileLogger(IMyTime time)
        {
            _time = time;
        }
        */
        public void Log(string message)
        {
            File.AppendAllText(@"C:\dev\WebAPI\logs.txt", message + Environment.NewLine);
        }
    }
}
