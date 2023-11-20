using Rolling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Rolling
{
    public class AggregationService
    {
        public IEnumerable<Measure> YearAggregate(Measure.AggregationDefinition aggregation, IEnumerable<Measure> measures)
        {
            var result = new List<Measure>();
            var yearGrouped = measures.GroupBy(x => x.Date.Year);

            foreach (var group in yearGrouped)
            {
                result.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = new DateTime(group.FirstOrDefault()!.Date.Year, 1, 1),
                    AggregatedValue = Aggregate(group, aggregation),
                });
            }

            return result;
        }

        public double Aggregate(IEnumerable<Measure> measures, Measure.AggregationDefinition aggregation)
        {
            switch (aggregation)
            {
                case Measure.AggregationDefinition.Sum:
                    return measures.Sum(x => x.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
        }
    }
}
