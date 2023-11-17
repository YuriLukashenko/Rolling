using Rolling.Data;
using Rolling.Models;
using Rolling.Rolling;

var slidingWindow = 12;
Console.WriteLine($"Sliding window: {slidingWindow}");

var rolling = new RollingService();
var seeder = new Seeder();
var filler = new Filler();

//var input = seeder.SeedInputs(100, 24);
//var input = seeder.SeedInputsRandom(200, 24);
//var input = seeder.SeedInputsMonths(200, 24, new DateTime(2022, 1, 1));
//var input = seeder.SeedInputsMissingMonths(200, 24, new DateTime(2022, 1, 1));
var input = seeder.SeedInputsFromExcel();

var ordered = input.OrderBy(x => x.Date);
var filled = filler.Fill(ordered, Filler.BinDefinition.Month);

var rolled = rolling.Rolling(Input.AggregationDefinition.Sum, slidingWindow, filled);

//var delta1Month = rolling.DeltaPercentage(rolled.ToList(), 1);
//Console.WriteLine("---------------------------------------------------------------------------");
//Console.WriteLine("Delta 1 month");
//foreach (var item in delta1Month)
//{
//    Console.WriteLine($"Date: {item.Date}");
//    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
//    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
//}

var delta12Month = rolling.DeltaPercentage(rolled.ToList(), 12);
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("Delta 12 month");
foreach (var item in delta12Month)
{
    Console.WriteLine($"Date: {item.Date}");
    Console.WriteLine($"Aggregated: {item.AggregatedValue}");
    Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
}