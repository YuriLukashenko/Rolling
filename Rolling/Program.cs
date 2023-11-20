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
var input = seeder.SeedB2B();

var ordered = input.OrderBy(x => x.Date);
var filled = filler.Fill(ordered, Filler.BinDefinition.Month);
var rolled = rolling.Rolling(Input.AggregationDefinition.Sum, slidingWindow, filled);
var yearly = aggregator.YearAggregate(Input.AggregationDefinition.Sum, filled);

//var delta1Month = rolling.DeltaPercentage(rolled.ToList(), 1);
//Console.WriteLine("---------------------------------------------------------------------------");
//Console.WriteLine("Delta 1 month");
//foreach (var item in delta1Month)
//{
//    Console.WriteLine($"Date: {item.Date}");
//    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
//    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
//}

var rolling12MonthsB2B = rolling.DeltaPercentage(rolled.ToList(), 12);
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("Rolling 12 months B2B:");
foreach (var item in rolling12MonthsB2B)
{
    Console.WriteLine($"Date: {item.Date}");
    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
}

var yearlyB2B = rolling.DeltaPercentage(yearly.ToList(), 1);
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("Årsutveckling");
foreach (var item in yearlyB2B)
{
    Console.WriteLine($"Date: {item.Date}");
    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
}

var input2 = seeder.SeedB2C();
var ordered2 = input2.OrderBy(x => x.Date);
var filled2 = filler.Fill(ordered2, Filler.BinDefinition.Month);
var rolled2 = rolling.Rolling(Input.AggregationDefinition.Sum, slidingWindow, filled2);

var rolling12MonthsB2C = rolling.DeltaPercentage(rolled2.ToList(), 12);
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("Rolling 12 months B2C:");
foreach (var item in rolling12MonthsB2C)
{
    Console.WriteLine($"Date: {item.Date}");
    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
}