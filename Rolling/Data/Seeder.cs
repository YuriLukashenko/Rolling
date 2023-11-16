using Rolling.Models;

namespace Rolling.Data
{
    public class Seeder
    {
        public List<Input> SeedInputs(int baseValue, int count)
        {
            var inputs = new List<Input>();

            for(var i=0; i<count; i++)
            {
                inputs.Add(new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1)
                });
            }

            return inputs;
        }

        public InputDto SetRollingDto(InputDto.AggregationDefinition aggregation, int slidingWindow, int baseValue, int count)
        {
            return new InputDto()
            {
                Aggregation = aggregation,
                SlidingWindow = slidingWindow,
                Inputs = SeedInputs(baseValue, count)
            };
        }
    }
}
