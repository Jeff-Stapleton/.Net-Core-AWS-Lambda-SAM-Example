using System;
using DebuggingExample.Interfaces;

namespace DebuggingExample.Services
{
    public class TimeService : ITimeService
    {
        public DateTime CurrentTimeUTC()
        {
            return DateTime.UtcNow;
        }
    }
}
