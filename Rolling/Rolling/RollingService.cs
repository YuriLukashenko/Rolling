using Rolling.Models;

namespace Rolling.Rolling
{
    public class RollingService
    {
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
                    AggregatedValue = Aggregate(temp, aggregation),
                });
            }

            return rolled;
        }

        private double Aggregate(IEnumerable<Input> Inputs, Input.AggregationDefinition aggregation)
        {
            switch (aggregation)
            {
                case Input.AggregationDefinition.Sum:
                    return Inputs.Sum(x => x.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
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
