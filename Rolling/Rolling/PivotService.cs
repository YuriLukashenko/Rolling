using Newtonsoft.Json.Linq;
using Rolling.Extensions;
using Rolling.Models;

namespace Rolling.Rolling
{
    public class PivotService
    {
        public void Run()
        {
            var data = GenerateDataForPivot();
            var pivotList = PivotList(data);
            DisplayPivot(pivotList);
        }

        public void RunWithLinqExtension()
        {
            var data = GenerateEmployeeDataForPivot();
            var result1 = data.Pivot(emp => emp.Department, emp2 => emp2.Function, lst => lst.Sum(emp => emp.Salary));
            DisplayPivot2(result1);
            var result2 = data.Pivot(emp => emp.Function, emp2 => emp2.Department, lst => lst.Count());
            DisplayPivot3(result2);
        }

        public Dictionary<DateTime, List<double>> PivotList(List<PivotDto> inputList)
        {
            // Pivot the list using LINQ
            var pivotedResult = inputList
                .GroupBy(item => item.Date)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(item => item.Value).ToList()
                );

            return pivotedResult;
        }

        public List<PivotDto> GenerateDataForPivot()
        {
            var result = new List<PivotDto>
            {
                new() { Date = DateTime.Parse("2024-01-01"), Value = 10 },
                new() { Date = DateTime.Parse("2024-01-01"), Value = 20 },
                new() { Date = DateTime.Parse("2024-01-02"), Value = 30 },
                new() { Date = DateTime.Parse("2024-01-02"), Value = 40 },
                new() { Date = DateTime.Parse("2024-01-03"), Value = 50 },
            };

            return result;
        }

        public List<Employee> GenerateEmployeeDataForPivot()
        {
            var result = new List<Employee>() {
                new () { Name = "Fons", Department = "R&D", Function = "Trainer", Salary = 2000 },
                new () { Name = "Jim", Department = "R&D", Function = "Trainer", Salary = 3000 },
                new () { Name = "Ellen", Department = "Dev", Function = "Developer", Salary = 4000 },
                new () { Name = "Mike", Department = "Dev", Function = "Consultant", Salary = 5000 },
                new () { Name = "Jack", Department = "R&D", Function = "Developer", Salary = 6000 },
                new () { Name = "Demy", Department = "Dev", Function = "Consultant", Salary = 2000 }};

            return result;
        }

        public void DisplayPivot(Dictionary<DateTime, List<double>> pivots)
        {
            foreach (var pivot in pivots)
            {
                Console.WriteLine($"Date: {pivot.Key}");

                foreach (var value in pivot.Value)
                {
                    Console.WriteLine($"  Value: {value}");
                }
            }
        }

        public void DisplayPivot2(Dictionary<string, Dictionary<string, decimal>> pivot)
        {
            foreach (var row in pivot)
            {
                Console.WriteLine(row.Key);
                foreach (var column in row.Value)
                {
                    Console.WriteLine("  " + column.Key + "\t" + column.Value);

                }
            }

            Console.WriteLine("----");
        }

        public void DisplayPivot3(Dictionary<string, Dictionary<string, int>> pivot)
        {
            foreach (var row in pivot)
            {
                Console.WriteLine(row.Key);
                foreach (var column in row.Value)
                {
                    Console.WriteLine("  " + column.Key + "\t" + column.Value);

                }
            }

            Console.WriteLine("----");
        }
    }

}
