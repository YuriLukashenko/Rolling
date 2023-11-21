using Rolling.Rolling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rolling.Models;
using System.Collections;

namespace Rolling.Data
{
    public class TestRunner
    {
        private readonly RollingService _rollingService;
        private readonly Seeder _seeder;
        private readonly Filler _filler;
        private readonly AggregationService _aggregationService;

        public TestRunner()
        {
            _rollingService = new RollingService();
            _seeder = new Seeder();
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
            var aggregated = filled.Select(x => x.SetAggregatedValue(x.Value));
            var delta = _rollingService.DeltaPercentage(aggregated.ToList(), 12);
            Printer.Print(delta, $"Monthly change (year over year) {title}:");
        }

        public void RunQuarterData(IEnumerable<Measure> filled, string title)
        {
            var aggregated = _aggregationService.QuarterAggregate(Measure.AggregationDefinition.Sum, filled);
            var delta = _rollingService.DeltaPercentage(aggregated.ToList(), 4);
            Printer.Print(delta, $"Kvartalsutveckling {title}:");
        }

        public void RunRolling(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var rolled = _rollingService.Rolling(Measure.AggregationDefinition.Sum, slidingWindow, filled);
            var delta = _rollingService.DeltaPercentage(rolled.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Rolling {deltaWindow} month {title}:");
        }

        public void RunAccumulated(IEnumerable<Measure> filled, string title, int slidingWindow, int deltaWindow, int start = 0)
        {
            var accumulated = _rollingService.Accumulated(Measure.AggregationDefinition.Sum, slidingWindow, filled);
            var delta = _rollingService.DeltaPercentage(accumulated.ToList(), deltaWindow, start);
            Printer.Print(delta, $"Delta Accumulated {deltaWindow} month {title}:");
        }

        public void RunYear(IEnumerable<Measure> filled, string title)
        {
            var yearly = _aggregationService.YearAggregate(Measure.AggregationDefinition.Sum, filled);
            var yearlyB2B = _rollingService.DeltaPercentage(yearly.ToList(), 1);
            Printer.Print(yearlyB2B, $"Årsutveckling {title}");
        }
    }
}
