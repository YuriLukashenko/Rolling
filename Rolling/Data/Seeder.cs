using Rolling.Models;

namespace Rolling.Data
{
    public class Seeder
    {
        public IEnumerable<Input> SeedInputs(int baseValue, int count)
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

        public IEnumerable<Input> SeedInputsMonths(int baseValue, int count, DateTime baseDate)
        {
            var inputs = new List<Input>();

            for (var i = 0; i < count; i++)
            {
                inputs.Add(new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1),
                    Date = baseDate.AddMonths(i)
                });
            }

            return inputs;
        }

        public IEnumerable<Input> SeedInputsMissingMonths(int baseValue, int count, DateTime baseDate)
        {
            var inputs = new List<Input>();

            for (var i = 0; i < count; i++)
            {
                //emulate missing months
                if(i!=0 && i%5 == 0)
                    continue;

                inputs.Add(new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1),
                    Date = baseDate.AddMonths(i)
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


        public InputDto SetRollingDto(InputDto.AggregationDefinition aggregation, int? slidingWindow, IEnumerable<Input> inputs)
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
