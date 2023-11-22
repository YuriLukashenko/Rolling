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

        public TestRunner()
        {
            _rollingService = new RollingService();
            _filler = new Filler();
            _aggregationService = new AggregationService();
        }

        public void Run(IEnumerable<Measure> inputMeasures, string title, int slidingWindow)
        {
            var filled = _filler.Fill(inputMeasures, Filler.BinDefinition.Month);
            
            RunMonthData(filled, title);
            //RunRollingDelta(filled, title, slidingWindow, 1, 0);
            RunAccumulated(filled, title, slidingWindow, 12);
            RunRolling(filled, title, slidingWindow, 12, 11);
            RunQuarterData(filled, title);
            RunYear(filled, title);
        }

        public void RunMonthData(IEnumerable<Measure> filled, string title)
        {
            var aggregated = _aggregationService
                .Monthize(filled)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _rollingService.DeltaPercentage(aggregated.ToList(), 12);
            Printer.Print(delta, $"Monthly change (year over year) {title}:");
        }

        public void RunQuarterData(IEnumerable<Measure> filled, string title)
        {
            var aggregated = _aggregationService
                .Quarterize(filled)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _rollingService.DeltaPercentage(aggregated.ToList(), 4);
            Printer.Print(delta, $"Kvartalsutveckling {title}:");
        }

        public void RunRolling(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var rolled = _rollingService
                .Rolling(filled, slidingWindow)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _rollingService.DeltaPercentage(rolled.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Rolling {deltaWindow} month {title}:");
        }

        public void RunAccumulated(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var accumulated = _rollingService
                .Accumulated(filled, slidingWindow)
                .SetAggregations(Measure.AggregationDefinition.Sum);

            var delta = _rollingService.DeltaPercentage(accumulated.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Accumulated {deltaWindow} month {title}:");
        }

        public void RunYear(IEnumerable<Measure> filled, string title)
        {
            var yearly = _aggregationService.Yearize(filled);
            var delta = _rollingService.DeltaPercentageSpecific(yearly.ToList(), Measure.AggregationDefinition.Sum);
            Printer.Print(delta, $"Årsutveckling {title}");
        }
    }
}
