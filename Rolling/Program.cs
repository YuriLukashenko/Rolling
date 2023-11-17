using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var rolling = new RollingService();
var sliding = new SlidingWindowService();
var seeder = new Seeder();
var filler = new Filler();

//var input = seeder.SeedInputs(100, 24);
//var input = seeder.SeedInputsRandom(200, 24);
//var input = seeder.SeedInputsMonths(200, 24, new DateTime(2022, 1, 1));
var input = seeder.SeedInputsMissingMonths(200, 24, new DateTime(2022, 1, 1));
var filled = filler.Fill(input, Filler.BinDefinition.Month);

var slidingWindow = 4;

var rollingDto = seeder.SetRollingDto(InputDto.AggregationDefinition.Sum, slidingWindow, filled);
var outputs = rolling.CalculateRollingDelta(rollingDto);

Console.WriteLine($"Sliding window: {slidingWindow}");
foreach (var output in outputs)
{
    Console.WriteLine($"Aggregated: {output.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {output.DeltaPercentage}");
}