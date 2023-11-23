using Rolling.Extensions;
using Rolling.Models;

namespace Rolling.Data
{
    public class Filler
    {
        public IEnumerable<Measure> Fill(IEnumerable<Measure> measures, Enums.BinDefinition bin)
        {
            if (bin == Enums.BinDefinition.NotSet)
                return measures;

            var startDate = measures.Min(x => x.Date).Date;
            var endDate = measures.Max(x => x.Date).Date;
            var dates = GetBinsBetween(startDate, endDate, bin);

            var filled = dates.Select(date => new Measure
                {
                    Date = date,
                    Value = measures.FirstOrDefault(x => x.Date == date)?.Value ?? 0
                });

            return filled;
        }

        static List<DateTime> GetBinsBetween(DateTime startDate, DateTime endDate, Enums.BinDefinition bin)
        {
            var months = new List<DateTime>();
            for (var date = startDate; date <= endDate; date = Increment(date, bin))
            {
                months.Add(date);
            }

            return months;
        }

        public static DateTime Increment(DateTime date, Enums.BinDefinition bin)
        {
            switch (bin)
            {
                case Enums.BinDefinition.Minute:
                    return date.AddMinutes(1);
                case Enums.BinDefinition.Hour:
                    return date.AddHours(1);
                case Enums.BinDefinition.Day:
                    return date.AddDays(1);
                case Enums.BinDefinition.Week:
                    return date.AddWeeks(1);
                case Enums.BinDefinition.Month:
                    return date.AddMonths(1);
                case Enums.BinDefinition.Quarter:
                    return date.AddQuarters(1);
                case Enums.BinDefinition.Year:
                    return date.AddYears(1);
                default:
                    return date;
            }
        }
    }
}
