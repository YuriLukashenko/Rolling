using Rolling.Models;

namespace Rolling.Rolling
{
    public class RollingService
    {
        public IEnumerable<Measure> Rolling(Measure[] measures, int? slidingWindow)
        {
            if(slidingWindow == null)
                return Enumerable.Empty<Measure>();

            var rolled = new List<Measure>();

            for (var i = 0; i < measures.Count(); i++)
            {
                var temp = new List<Measure>();
                var from = i - slidingWindow.Value < 0 ? 0 : i - slidingWindow.Value + 1;
                var to = i + 1;

                var slice = measures[from..to];
                temp.AddRange(slice);

                var item = measures[i];

                rolled.Add(new Measure()
                {
                    Id = item.Id,
                    Date = item.Date,
                    Value = item.Value,
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return rolled;
        }

        public IEnumerable<Measure> Accumulated(Measure[] measures, int? slidingWindow)
        {
            if (slidingWindow == null)
                return Enumerable.Empty<Measure>();

            var accumulated = new List<Measure>();

            for (var i = 0; i < measures.Count(); i++)
            {

                var temp = new List<Measure>();
                var from = i - (i % slidingWindow) <= 0 ? 0 : i - (i % slidingWindow.Value);
                var to = i + 1;

                var slice = measures[from..to];
                temp.AddRange(slice);

                var item = measures[i];

                accumulated.Add(new Measure()
                {
                    Id = item.Id,
                    Date = item.Date,
                    Value = item.Value,
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return accumulated;
        }
    }
}
