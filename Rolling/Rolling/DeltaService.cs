using Rolling.Models;

namespace Rolling.Rolling
{
    public class DeltaService
    {
        private readonly AggregationService _aggregationService;
        public DeltaService()
        {
            _aggregationService = new AggregationService();
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
                    DeltaPercentage = prevValue == 0.0 ? null : delta,
                    Error = prevValue == 0.0 ? "Divide be zero": null 
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
                    DeltaPercentage = prevValue == 0.0 ? null : delta,
                    Error = prevValue == 0.0 ? "Divide be zero" : null
                });
            }

            return deltaPercents;
        }
    }
}
