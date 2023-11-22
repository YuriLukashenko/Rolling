using Rolling.Extensions;
using Rolling.Models;

namespace Rolling.Rolling
{
    public class RollingService
    {
        private readonly AggregationService _aggregationService;
        public RollingService()
        {
            _aggregationService = new AggregationService();
        }

        public IEnumerable<Measure> Rolling(IEnumerable<Measure> measures, int? slidingWindow)
        {
            if(slidingWindow == null)
                return Enumerable.Empty<Measure>();

            var rolled = new List<Measure>();

            for (var i = 0; i < measures.Count(); i++)
            {
                var temp = new List<Measure>();
                for (var j = 0; j < measures.Count(); j++)
                {
                    if (j > i - slidingWindow && j <= i)
                    {
                        temp.Add(measures.ElementAt(j));
                    }
                }

                rolled.Add(new Measure()
                {
                    Id = measures.ElementAt(i).Id,
                    Date = measures.ElementAt(i).Date,
                    Value = measures.ElementAt(i).Value,
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return rolled;
        }

        public IEnumerable<Measure> Accumulated(IEnumerable<Measure> measures, int? slidingWindow)
        {
            if (slidingWindow == null)
                return Enumerable.Empty<Measure>();

            var accumulated = new List<Measure>();

            for (var i = 0; i < measures.Count(); i++)
            {
                var temp = new List<Measure>();
                for (var j = 0; j < measures.Count(); j++)
                {
                    if (j >= i - (i % slidingWindow) && j <= i)
                    {
                        temp.Add(measures.ElementAt(j));
                    }
                }

                accumulated.Add(new Measure()
                {
                    Id = measures.ElementAt(i).Id,
                    Date = measures.ElementAt(i).Date,
                    Value = measures.ElementAt(i).Value,
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return accumulated;
        }


        public IEnumerable<Measure> DeltaPercentage(IEnumerable<Measure> measures, int window, int start = 0)
        {
            var deltaPercents = new List<Measure>();
            for (var i = start + window; i < measures.Count(); i++)
            {
                var thisItem = measures.ElementAt(i);
                var prevItem = measures.ElementAt(i - window);
                var thisValue = thisItem.AggregatedValue;
                var prevValue = prevItem.AggregatedValue;

                var delta = ((thisValue - prevValue) / prevValue) * 100;

                deltaPercents.Add(new Measure()
                {
                    Id = thisItem.Id,
                    Date = thisItem.Date,
                    Value = thisItem.Value,
                    AggregatedValue = thisItem.AggregatedValue,
                    DeltaPercentage = delta
                });
            }

            return deltaPercents;
        }

        public IEnumerable<Measure> DeltaPercentageSpecific(IEnumerable<Measure> measures, Measure.AggregationDefinition aggregation)
        {
            var deltaPercents = new List<Measure>();
            for (var i = 1; i < measures.Count(); i++)
            {
                var thisItem = measures.ElementAt(i);
                var prevItem = measures.ElementAt(i - 1);
                var thisCount = thisItem.BunchValues.Count();
                var thisValue = _aggregationService.Aggregate(thisItem.BunchValues.Take(thisCount), aggregation);
                var prevValue = _aggregationService.Aggregate(prevItem.BunchValues.Take(thisCount), aggregation);

                var delta = ((thisValue - prevValue) / prevValue) * 100;

                deltaPercents.Add(new Measure()
                {
                    Id = thisItem.Id,
                    Date = thisItem.Date,
                    Value = thisItem.Value,
                    AggregatedValue = thisValue,
                    DeltaPercentage = delta
                });
            }

            return deltaPercents;
        }
    }
}
