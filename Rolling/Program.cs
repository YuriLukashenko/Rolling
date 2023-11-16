using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var rolling = new RollingService();
var sliding = new SlidingWindowService();
var seeder = new Seeder();

var input = seeder.SeedInputs(100, 24);
//var input = seeder.SeedInputsRandom(200, 24);

var slidingWindow = sliding.CalculateSlidingWindow
(SlidingWindowService.BinDefinition.Month, SlidingWindowService.BinDefinition.Quarter);

var rollingDto = seeder.SetRollingDto(InputDto.AggregationDefinition.Sum, slidingWindow, input);
var outputs = rolling.CalculateRollingDelta(rollingDto);

Console.WriteLine($"Sliding window: {slidingWindow}");
foreach (var output in outputs)
{
    Console.WriteLine($"Aggregated: {output.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {output.DeltaPercentage}");
}