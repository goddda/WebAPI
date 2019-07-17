using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    class MyTime : IMyTime
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:SS");
        }
    }
}
