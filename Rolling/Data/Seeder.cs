using Rolling.Models;

namespace Rolling.Data
{
    public class Seeder
    {
        public IEnumerable<Measure> SeedInputs(int baseValue, int count)
        {
            var inputs = new List<Measure>();

            for(var i=0; i<count; i++)
            {
                inputs.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1)
                });
            }

            return inputs;
        }

        public IEnumerable<Measure> SeedInputsMonths(int baseValue, int count, DateTime baseDate)
        {
            var inputs = new List<Measure>();

            for (var i = 0; i < count; i++)
            {
                inputs.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1),
                    Date = baseDate.AddMonths(i)
                });
            }

            return inputs;
        }

        public IEnumerable<Measure> SeedInputsMissingMonths(int baseValue, int count, DateTime baseDate)
        {
            var inputs = new List<Measure>();

            for (var i = 0; i < count; i++)
            {
                //emulate missing months
                if(i!=0 && i%5 == 0)
                    continue;

                inputs.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = baseValue * (i + 1),
                    Date = baseDate.AddMonths(i)
                });
            }

            return inputs;
        }

        public List<Measure> SeedInputsRandom(int maxValue, int count)
        {
            var inputs = new List<Measure>();
            Random rnd = new Random();

            for (var i = 0; i < count; i++)
            {
                inputs.Add(new Measure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = rnd.Next(1, 200)
                });
            }

            return inputs;
        }

        public IEnumerable<Measure> SeedB2B()
        {
            return new List<Measure>()
            {
                new() { Id = Guid.NewGuid().ToString(), Value = 41, Date = new DateTime(2020, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 25, Date = new DateTime(2020, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 9, Date = new DateTime(2020, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 16, Date = new DateTime(2020, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 24, Date = new DateTime(2020, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 68, Date = new DateTime(2020, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 71, Date = new DateTime(2020, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 27, Date = new DateTime(2020, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 54, Date = new DateTime(2020, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 24, Date = new DateTime(2020, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 29, Date = new DateTime(2020, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 86, Date = new DateTime(2020, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 83, Date = new DateTime(2021, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 53, Date = new DateTime(2021, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 66, Date = new DateTime(2021, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 59, Date = new DateTime(2021, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 45, Date = new DateTime(2021, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 51, Date = new DateTime(2021, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 44, Date = new DateTime(2021, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 20, Date = new DateTime(2021, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 83, Date = new DateTime(2021, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 12, Date = new DateTime(2021, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 29, Date = new DateTime(2021, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 5, Date = new DateTime(2021, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 96, Date = new DateTime(2022, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 45, Date = new DateTime(2022, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 57, Date = new DateTime(2022, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 73, Date = new DateTime(2022, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 37, Date = new DateTime(2022, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 42, Date = new DateTime(2022, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 82, Date = new DateTime(2022, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 78, Date = new DateTime(2022, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 57, Date = new DateTime(2022, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 35, Date = new DateTime(2022, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 79, Date = new DateTime(2022, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 39, Date = new DateTime(2022, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 31, Date = new DateTime(2023, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 90, Date = new DateTime(2023, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 75, Date = new DateTime(2023, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 72, Date = new DateTime(2023, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 49, Date = new DateTime(2023, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 32, Date = new DateTime(2023, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 97, Date = new DateTime(2023, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 43, Date = new DateTime(2023, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 38, Date = new DateTime(2023, 9, 1)},
            };
        }

        public IEnumerable<Measure> SeedB2C()
        {
            return new List<Measure>()
            {
                new() { Id = Guid.NewGuid().ToString(), Value = 71, Date = new DateTime(2020, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 98, Date = new DateTime(2020, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 23, Date = new DateTime(2020, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 53, Date = new DateTime(2020, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 42, Date = new DateTime(2020, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 51, Date = new DateTime(2020, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 89, Date = new DateTime(2020, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 37, Date = new DateTime(2020, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 51, Date = new DateTime(2020, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 98, Date = new DateTime(2020, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 9, Date = new DateTime(2020, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 89, Date = new DateTime(2020, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 81, Date = new DateTime(2021, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 40, Date = new DateTime(2021, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 48, Date = new DateTime(2021, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 46, Date = new DateTime(2021, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 13, Date = new DateTime(2021, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 51, Date = new DateTime(2021, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 40, Date = new DateTime(2021, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 93, Date = new DateTime(2021, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 77, Date = new DateTime(2021, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 96, Date = new DateTime(2021, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 31, Date = new DateTime(2021, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 43, Date = new DateTime(2021, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 40, Date = new DateTime(2022, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 28, Date = new DateTime(2022, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 18, Date = new DateTime(2022, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 99, Date = new DateTime(2022, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 9, Date = new DateTime(2022, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 21, Date = new DateTime(2022, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 31, Date = new DateTime(2022, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 84, Date = new DateTime(2022, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 15, Date = new DateTime(2022, 9, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 7, Date = new DateTime(2022, 10, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 62, Date = new DateTime(2022, 11, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 96, Date = new DateTime(2022, 12, 1)},

                new() { Id = Guid.NewGuid().ToString(), Value = 12, Date = new DateTime(2023, 1, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 12, Date = new DateTime(2023, 2, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 9, Date = new DateTime(2023, 3, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 56, Date = new DateTime(2023, 4, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 12, Date = new DateTime(2023, 5, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 65, Date = new DateTime(2023, 6, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 11, Date = new DateTime(2023, 7, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 96, Date = new DateTime(2023, 8, 1)},
                new() { Id = Guid.NewGuid().ToString(), Value = 26, Date = new DateTime(2023, 9, 1)},
            };
        }
    }
}
