namespace Rolling.Models
{
    public class Output
    {
        public string Id { get; set; } = string.Empty;
        public double? AggregatedValue { get; set; }
        public double? DeltaPercentage { get; set; }
    }
}
