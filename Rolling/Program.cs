using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var service = new RollingService();
var seeder = new Seeder();

//var input = seeder.SeedInputs(200, 24);
var input = seeder.SeedInputsRandom(200, 24);

var rollingDto = seeder.SetRollingDto(InputDto.AggregationDefinition.Sum, 4, input);
var outputs = service.CalculateRollingDelta(rollingDto);

foreach (var output in outputs)
{
    Console.WriteLine($"Aggregated: {output.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {output.DeltaPercentage}");
}