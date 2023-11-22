﻿using Rolling.Models;

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
                    BunchValues = group.Select(x => x.Value).ToList(),
                    AggregatedValue = Aggregate(group, aggregation),
                });
            }

            return result;
        }

        public IEnumerable<Measure> QuarterAggregate(Measure.AggregationDefinition aggregation, IEnumerable<Measure> measures)
        {
            var result = new List<Measure>();
            var quarterGrouped = measures.GroupBy(x => new { x.Date.Year, Quarter = (x.Date.Month - 1) / 3 });

            foreach (var group in quarterGrouped)
            {
                result.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = new DateTime(group.FirstOrDefault()!.Date.Year, group.Key.Quarter * 3 + 1, 1),
                    BunchValues = group.Select(x => x.Value).ToList(),
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
                case Measure.AggregationDefinition.Avg:
                    return measures.Average(x => x.Value);
                case Measure.AggregationDefinition.Min:
                    return measures.Min(x => x.Value);
                case Measure.AggregationDefinition.Max:
                    return measures.Max(x => x.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
        }

        public double Aggregate(IEnumerable<double> measures, Measure.AggregationDefinition aggregation)
        {
            switch (aggregation)
            {
                case Measure.AggregationDefinition.Sum:
                    return measures.Sum();
                case Measure.AggregationDefinition.Avg:
                    return measures.Average();
                case Measure.AggregationDefinition.Min:
                    return measures.Min();
                case Measure.AggregationDefinition.Max:
                    return measures.Max();
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
        }
    }
}
