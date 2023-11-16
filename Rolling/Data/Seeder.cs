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

        public List<Input> SeedInputsRandom(int maxValue, int count)
        {
            var inputs = new List<Input>();
            Random rnd = new Random();

            for (var i = 0; i < count; i++)
            {
                inputs.Add(new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = rnd.Next(1, 200)
                });
            }

            return inputs;
        }


        public InputDto SetRollingDto(InputDto.AggregationDefinition aggregation, int slidingWindow, List<Input> inputs)
        {
            return new InputDto()
            {
                Aggregation = aggregation,
                SlidingWindow = slidingWindow,
                Inputs = inputs
            };
        }
    }
}
