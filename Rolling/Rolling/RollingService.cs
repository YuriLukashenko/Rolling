using Rolling.Models;

namespace Rolling.Rolling
{
    public class RollingService
    {
        public IEnumerable<Measure> Rolling(IEnumerable<Measure> measures, int? slidingWindow)
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
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return rolled;
        }

        public IEnumerable<Measure> Accumulated(IEnumerable<Measure> measures, int? slidingWindow)
        {
            if (slidingWindow == null)
                return Enumerable.Empty<Measure>();

            var accumulated = new List<Measure>();

            for (var i = 0; i < measures.Count(); i++)
            {
                var temp = new List<Measure>();
                for (var j = 0; j < measures.Count(); j++)
                {
                    if (j >= i - (i % slidingWindow) && j <= i)
                    {
                        temp.Add(measures.ElementAt(j));
                    }
                }

                accumulated.Add(new Measure()
                {
                    Id = measures.ElementAt(i).Id,
                    Date = measures.ElementAt(i).Date,
                    Value = measures.ElementAt(i).Value,
                    BunchValues = temp.Select(x => x.Value),
                });
            }

            return accumulated;
        }
    }
}
