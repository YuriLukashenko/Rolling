using Rolling.Models;

namespace Rolling.Rolling
{
    public class RollingService
    {
        public IEnumerable<Output> CalculateRollingDelta(InputDto inputDto)
        {
            var inputs = inputDto.Inputs;
            var window = inputDto.SlidingWindow;
            var aggregation = inputDto.Aggregation;

            var outputs = new List<Output>();

            for (var i = 0; i < inputs.Count(); i++)
            {
                var temp = new List<Input>();
                for (var j = 0; j < inputs.Count(); j++)
                {
                    if (j > i - window && j <= i)
                    {
                        temp.Add(inputs.ElementAt(j));
                    }
                }

                outputs.Add(new Output()
                {
                    Id = inputs.ElementAt(i).Id,
                    AggregatedValue = Aggregate(temp, aggregation)
                });
            }

            SetDeltaPercentage(outputs);
            return outputs;
        }

        private double Aggregate(IEnumerable<Input> Inputs, InputDto.AggregationDefinition aggregation)
        {
            switch (aggregation)
            {
                case InputDto.AggregationDefinition.Sum:
                    return Inputs.Sum(x => x.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
        }

        private void SetDeltaPercentage(List<Output> outputs)
        {
            for (var i = 1; i < outputs.Count(); i++)
            {
                var result = ((outputs[i].AggregatedValue - outputs[i - 1].AggregatedValue) /
                              outputs[i - 1].AggregatedValue) * 100;

                outputs[i].DeltaPercentage = result;
            }
        }
    }
}
