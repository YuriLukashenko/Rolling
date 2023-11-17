using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rolling.Models;

namespace Rolling.Data
{
    public class Filler
    {
        public enum BinDefinition { NotSet, Minute, Hour, Day, Week, Month, Quarter, Year }

        public IEnumerable<Input> Fill(IEnumerable<Input> inputs, Filler.BinDefinition bin)
        {
            if (bin == Filler.BinDefinition.NotSet)
                return inputs;

            var startDate = inputs.Min(x => x.Date).Date;
            var endDate = inputs.Max(x => x.Date).Date;
            var dates = GetBinsBetween(startDate, endDate, bin);

            var filled = dates.Select(date => new Input
                {
                    Date = date,
                    Value = inputs.FirstOrDefault(x => x.Date == date)?.Value ?? 0
                });

            return filled;
        }

        static List<DateTime> GetBinsBetween(DateTime startDate, DateTime endDate, Filler.BinDefinition bin)
        {
            var months = new List<DateTime>();
            for (var date = startDate; date <= endDate; date = Increment(date, bin))
            {
                months.Add(date);
            }

            return months;
        }

        public static DateTime Increment(DateTime date, Filler.BinDefinition bin)
        {
            switch (bin)
            {
                case Filler.BinDefinition.NotSet:
                    return date;
                case Filler.BinDefinition.Minute:
                    return date;
                case Filler.BinDefinition.Hour:
                    return date;
                case Filler.BinDefinition.Day:
                    return date;
                case Filler.BinDefinition.Week:
                    return date;
                case Filler.BinDefinition.Month:
                    return date.AddMonths(1);
                case Filler.BinDefinition.Quarter:
                    return date;
                case Filler.BinDefinition.Year:
                    return date;
                default:
                    return date;
            }
        }
    }
}
