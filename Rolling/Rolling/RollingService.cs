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

        public IEnumerable<Input> Rolling(Input.AggregationDefinition aggregation, int? slidingWindow, IEnumerable<Input> inputs)
        {
            if(slidingWindow == null)
                return Enumerable.Empty<Input>();

            var rolled = new List<Input>();

            for (var i = 0; i < inputs.Count(); i++)
            {
                var temp = new List<Input>();
                for (var j = 0; j < inputs.Count(); j++)
                {
                    if (j > i - slidingWindow && j <= i)
                    {
                        temp.Add(inputs.ElementAt(j));
                    }
                }

                rolled.Add(new Input()
                {
                    Id = inputs.ElementAt(i).Id,
                    Date = inputs.ElementAt(i).Date,
                    Value = inputs.ElementAt(i).Value,
                    AggregatedValue = _aggregationService.Aggregate(temp, aggregation),
                });
            }

            return rolled;
        }



        public List<Input> DeltaPercentage(List<Input> inputs, int window)
        {
            var deltaPercents = new List<Input>();
            for (var i = (window * 2) - 1; i < inputs.Count; i++)
            {
                var item = inputs.ElementAt(i);

                var delta = ((item.AggregatedValue - inputs[i - window].AggregatedValue) /
                              inputs[i - window].AggregatedValue) * 100;

                deltaPercents.Add(new Input()
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
