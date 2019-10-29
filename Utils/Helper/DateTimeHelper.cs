using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Helper
{

    public static class DateTimeHelper
    {
        public static DateTime BrazilNow => DateTime.Now.ToBrazilTime();

        public static DateTime ToBrazilTime(this DateTime date)
        {
            var brazilTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Local, brazilTimeZoneInfo);
        }

        public static DateTime ToTimeZone(this DateTime date, string timeZoneId)
        {
            var validTimeZone = TimeZoneInfo.GetSystemTimeZones().Any(x => x.Id == timeZoneId);

            if (!validTimeZone) throw new InvalidTimeZoneException();

            var brazilTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Local, brazilTimeZoneInfo);
        }
    }
}
