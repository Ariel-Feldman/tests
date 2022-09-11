using System;

namespace Parana.Utilities
{
    public static class TimeConvertor
    {
        public static string IntToStringConvert(int timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime(); // unixTimeStamp
            return dateTime.ToString("MM/dd/yyyy");
        }
    }
}