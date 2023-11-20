using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var slidingWindow = 12;
Console.WriteLine($"Sliding window: {slidingWindow}");

var rolling = new RollingService();
var seeder = new Seeder();
var filler = new Filler();
var aggregator = new AggregationService();

//var input = seeder.SeedInputs(100, 24);
//var input = seeder.SeedInputsRandom(200, 24);
//var input = seeder.SeedInputsMonths(200, 24, new DateTime(2022, 1, 1));
//var input = seeder.SeedInputsMissingMonths(200, 24, new DateTime(2022, 1, 1));

var measuresB2B = seeder.SeedB2B().OrderBy(x => x.Date);
var filled = filler.Fill(measuresB2B, Filler.BinDefinition.Month);
var rolled = rolling.Rolling(Measure.AggregationDefinition.Sum, slidingWindow, filled);
var yearly = aggregator.YearAggregate(Measure.AggregationDefinition.Sum, filled);

var delta1Month = rolling.DeltaPercentage(rolled.ToList(), 1);
Printer.Print(delta1Month, "Delta 1 month B2B:");

var rolling12MonthsB2B = rolling.DeltaPercentage(rolled.ToList(), 12);
Printer.Print(rolling12MonthsB2B, "Rolling 12 months B2B:");

var yearlyB2B = rolling.DeltaPercentage(yearly.ToList(), 1);
Printer.Print(yearlyB2B, "Årsutveckling");

var measuresB2C = seeder.SeedB2C();
var ordered2 = measuresB2C.OrderBy(x => x.Date);
var filled2 = filler.Fill(ordered2, Filler.BinDefinition.Month);
var rolled2 = rolling.Rolling(Measure.AggregationDefinition.Sum, slidingWindow, filled2);

var rolling12MonthsB2C = rolling.DeltaPercentage(rolled2.ToList(), 12);
Printer.Print(rolling12MonthsB2C, "Rolling");