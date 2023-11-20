using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rolling.Models;

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
            }
        }
    }
}
