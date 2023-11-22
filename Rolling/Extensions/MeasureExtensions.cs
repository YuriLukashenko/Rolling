using Rolling.Models;
using Rolling.Rolling;

namespace Rolling.Extensions
{
    public static class MeasureExtensions
    {
        public static Measure SetAggregatedValue(this Measure measure, double aggregatedValue)
        {
            measure.AggregatedValue = aggregatedValue;
            return measure;
        }

        public static IEnumerable<Measure> SetAggregations(this IEnumerable<Measure> measures, Measure.AggregationDefinition aggregation)
        {
            var aggregationService = new AggregationService();
            foreach (var measure in measures)
            {
                measure.AggregatedValue = aggregationService.Aggregate(measure.BunchValues, aggregation);
            }

            return measures;
        }
    }
}
