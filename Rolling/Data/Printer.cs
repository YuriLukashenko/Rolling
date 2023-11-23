using Rolling.Models;
using System;

namespace Rolling.Data
{
    public static class Printer
    {
        public static void Print(IEnumerable<Measure> measures, string title)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"{title}");
            foreach (var item in measures)
            {
                Console.WriteLine($"Date: {item.Date}");
                Console.WriteLine($"Aggregated: {item.AggregatedValue}");
                Console.WriteLine($"DeltaPercentage: {item.DeltaPercentage}");
                if (!string.IsNullOrEmpty(item.Error))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {item.Error}");
                    Console.ResetColor();
                }
            }
        }
    }
}
