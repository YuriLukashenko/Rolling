using Rolling.Rolling;
using Rolling.Models;
using Rolling.Extensions;

namespace Rolling.Data
{
    public class TestRunner
    {
        private readonly RollingService _rollingService;
        private readonly Filler _filler;
        private readonly AggregationService _aggregationService;
        private readonly DeltaService _deltaService;

        public TestRunner()
        {
            _rollingService = new RollingService();
            _filler = new Filler();
            _aggregationService = new AggregationService();
            _deltaService = new DeltaService();
        }

        public IEnumerable<Enums.TestDefinition> GetAllTests()
        {
            return Enum.GetValues(typeof(Enums.TestDefinition)).Cast<Enums.TestDefinition>();
        }

        public void Run(IEnumerable<Measure> inputMeasures, string title, int slidingWindow, IEnumerable<Enums.TestDefinition> tests)
        {
            var filled = _filler.Fill(inputMeasures, Enums.BinDefinition.Month);

            foreach (var test in tests)
            {
                switch (test)
                {
                    case Enums.TestDefinition.Month:
                        RunMonthData(filled, title);
                        break;
                    case Enums.TestDefinition.Accumulated:
                        RunAccumulated(filled, title, slidingWindow, 12);
                        break;
                    case Enums.TestDefinition.Rolling:
                        //RunRolling(filled, title, slidingWindow, 1, 0);
                        RunRolling(filled, title, slidingWindow, 12, 11);
                        break;
                    case Enums.TestDefinition.Quarter:
                        RunQuarterData(filled, title);
                        break;
                    case Enums.TestDefinition.YearByLastDate:
                        RunYear(filled, title);
                        break;
                }
            }
        }

        public void RunMonthData(IEnumerable<Measure> filled, string title)
        {
            var aggregated = _aggregationService
                .Monthize(filled)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _deltaService.DeltaPercentage(aggregated.ToList(), 12);
            Printer.Print(delta, $"Monthly change (year over year) {title}:");
        }

        public void RunQuarterData(IEnumerable<Measure> filled, string title)
        {
            var aggregated = _aggregationService
                .Quarterize(filled)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _deltaService.DeltaPercentage(aggregated.ToList(), 4);
            Printer.Print(delta, $"Kvartalsutveckling {title}:");
        }

        public void RunRolling(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var rolled = _rollingService
                .Rolling(filled.ToArray(), slidingWindow)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _deltaService.DeltaPercentage(rolled.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Rolling {deltaWindow} month {title}:");
        }

        public void RunAccumulated(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var accumulated = _rollingService
                .Accumulated(filled.ToArray(), slidingWindow)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _deltaService.DeltaPercentage(accumulated.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Accumulated {deltaWindow} month {title}:");
        }

        public void RunYear(IEnumerable<Measure> filled, string title)
        {
            var yearly = _aggregationService.Yearize(filled);
            var delta = _deltaService.DeltaPercentageSpecific(yearly.ToList(), Measure.AggregationDefinition.Sum);
            Printer.Print(delta, $"Årsutveckling {title}");
        }
    }
}
