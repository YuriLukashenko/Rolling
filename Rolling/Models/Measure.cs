namespace Rolling.Models
{
    public class Measure
    {
        public enum AggregationDefinition { Sum } //Avg, Min, Max ...

        public string Id { get; set; } = string.Empty;
        public double Value { get; set; }
        public double AggregatedValue { get; set; }
        public double? DeltaPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}
