﻿using Rolling.Data;
using Rolling.Rolling;

var slidingWindow = 12;
Console.WriteLine($"Sliding window: {slidingWindow}");

var seeder = new Seeder();
var runner = new TestRunner();

//var input = seeder.SeedInputs(100, 24);
//var input = seeder.SeedInputsRandom(200, 24);
//var input = seeder.SeedInputsMonths(200, 24, new DateTime(2022, 1, 1));

//var measuresB2B = seeder.SeedB2B().OrderBy(x => x.Date);
//runner.Run(measuresB2B, "B2B", slidingWindow, new List<Enums.TestDefinition>() { Enums.TestDefinition.Accumulated });

//var measuresB2C = seeder.SeedB2C().OrderBy(x => x.Date);
//runner.Run(measuresB2C, "B2C", slidingWindow, runner.GetAllTests());

//var missing = seeder.SeedInputsMissingMonths(200, 24, new DateTime(2022, 1, 1)).OrderBy(x => x.Date);
//runner.Run(missing, "MissingMonths", 4, runner.GetAllTests());


new PivotService().RunWithLinqExtension();