using Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2Aurimas.Infrastructure
{
    public class DebugLogger : IMyLogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
        
    }
}
