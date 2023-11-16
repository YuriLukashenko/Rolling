using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var service = new RollingService();
var seeder = new Seeder();

var rollingDto = seeder.SetRollingDto(InputDto.AggregationDefinition.Sum, 5, 100, 12);
var outputs = service.CalculateRollingDelta(rollingDto);

foreach (var output in outputs)
{
    Console.WriteLine($"Aggregated: {output.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {output.DeltaPercentage}");
}