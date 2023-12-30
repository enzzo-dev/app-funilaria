using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Domain.Helpers
{
    public static class DateTimeBrasil
    {
        private const string Windows_BrasilTimeZoneId = "E. South America Standard Time";
        private const string Mac_BrasilTimeZoneId = "America/Sao_Paulo";

        private static TimeZoneInfo lTimeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(x => x.Id == Windows_BrasilTimeZoneId || x.Id == Mac_BrasilTimeZoneId);

        public static DateTime Now
            => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, lTimeZone);

        public static DateTime Today
            => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, lTimeZone).Date;

        public static DateTime Yesterday
            => Today.AddDays(-1);

        public static DateTime Tomorrow
            => Today.AddDays(1);

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = TimeZoneInfo.ConvertTimeFromUtc(epoch, lTimeZone);
            return epoch.AddMilliseconds(unixTime);
        }

        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = TimeZoneInfo.ConvertTimeFromUtc(epoch, lTimeZone);
            return Convert.ToInt64((date - epoch).TotalMilliseconds);
        }

        public static DateTime ToDateTimeBrasil(this DateTime date)
            => TimeZoneInfo.ConvertTimeFromUtc(date, lTimeZone);
    }
}
