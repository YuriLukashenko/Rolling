using Rolling.Models;
using Rolling.Rolling;

var service = new RollingService();

var outputs = service.CalculateRollingDelta(new InputDto()
{
    Aggregation = InputDto.AggregationDefinition.Sum,
    SlidingWindow = 4,
    Inputs = new List<Input>()
    {
        new() {Id = Guid.NewGuid().ToString(), Value = 100},
        new() {Id = Guid.NewGuid().ToString(), Value = 200},
        new() {Id = Guid.NewGuid().ToString(), Value = 300},
        new() {Id = Guid.NewGuid().ToString(), Value = 400},
        new() {Id = Guid.NewGuid().ToString(), Value = 500},
        new() {Id = Guid.NewGuid().ToString(), Value = 600},
        new() {Id = Guid.NewGuid().ToString(), Value = 700},
        new() {Id = Guid.NewGuid().ToString(), Value = 800},
        new() {Id = Guid.NewGuid().ToString(), Value = 900},
        new() {Id = Guid.NewGuid().ToString(), Value = 1000},
        new() {Id = Guid.NewGuid().ToString(), Value = 1100},
        new() {Id = Guid.NewGuid().ToString(), Value = 1200},
    }
});

foreach (var output in outputs)
{
    Console.WriteLine($"Aggregated: {output.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {output.DeltaPercentage}");
}