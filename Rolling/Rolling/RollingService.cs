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

        public IEnumerable<Measure> Rolling(Measure.AggregationDefinition aggregation, int? slidingWindow, IEnumerable<Measure> measures)
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
                    AggregatedValue = _aggregationService.Aggregate(temp, aggregation),
                });
            }

            return rolled;
        }



        public List<Measure> DeltaPercentage(List<Measure> measures, int window)
        {
            var deltaPercents = new List<Measure>();
            for (var i = (window * 2) - 1; i < measures.Count; i++)
            {
                var item = measures.ElementAt(i);

                var delta = ((item.AggregatedValue - measures[i - window].AggregatedValue) /
                             measures[i - window].AggregatedValue) * 100;

                deltaPercents.Add(new Measure()
                {
                    Id = item.Id,
                    Date = item.Date,
                    Value = item.Value,
                    AggregatedValue = item.AggregatedValue,
                    DeltaPercentage = delta
                });
            }

            return deltaPercents;
        }
    }
}
