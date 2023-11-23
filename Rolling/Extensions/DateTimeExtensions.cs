using Rolling.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static int? GetQuarter(this DateTime? fromDate)
        {
            if (!fromDate.HasValue)
                return null;

            int month = fromDate.Value.Month - 1;
            int month2 = Math.Abs(month / 3) + 1;
            return month2;
        }

        public static DateTime StartOfQuarter(this DateTime dt)
        {
            int diff = (dt.Month - 1) % 3;
            return dt.AddMonths(-1 * diff).Date;
        }

        public static DateTime StartOfQuarter(this DateTime dt, int monthNumber)
        {
            int diff = (monthNumber - 1) % 3;
            return dt.AddMonths(-1 * diff).Date;
        }

        public static DateTime AddWeeks(this DateTime dt, int weeksCount)
        {
            return dt.AddDays(7 * weeksCount);
        }

        public static DateTime AddQuarters(this DateTime dt, int quarterCount)
        {
            return dt.AddMonths(3 * quarterCount);
        }

        public static DateTime LastDateByBin(this DateTime dt, Enums.BinDefinition? bin) => bin switch
        {
            Enums.BinDefinition.NotSet => dt.Date.AddYears(-1),
            Enums.BinDefinition.Minute => dt.Date.AddMinutes(-1),
            Enums.BinDefinition.Hour => dt.Date.AddHours(-1),
            Enums.BinDefinition.Day => dt.Date.AddDays(-1),
            Enums.BinDefinition.Week => dt.Date.AddWeeks(-1),
            Enums.BinDefinition.Month => dt.Date.AddMonths(-1),
            Enums.BinDefinition.Quarter => dt.Date.AddQuarters(-1),
            Enums.BinDefinition.Year => dt.Date.AddYears(-1),
            null => dt.Date.AddYears(-1),
            _ => throw new ArgumentOutOfRangeException(nameof(bin), bin, null)
        };
    }

}
