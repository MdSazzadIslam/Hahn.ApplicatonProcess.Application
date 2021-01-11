using Hahn.ApplicatonProcess.December2020.Data.Common.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Utils;
using System;


namespace Hahn.ApplicatonProcess.December2020.Data.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => GetCurrentDateTime();

        public DateTime GetCurrentDateTime()
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(DateTimeConfig.DEFAULT_TIME_ZONE);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
        }
    }
}
