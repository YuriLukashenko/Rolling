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
    }

}
