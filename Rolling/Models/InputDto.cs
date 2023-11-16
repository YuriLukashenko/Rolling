namespace Rolling.Models
{
    public class InputDto
    {
        public enum AggregationDefinition { Sum } //Avg, Min, Max ...

        public IEnumerable<Input> Inputs { get; set; } = new List<Input>();

        public int? SlidingWindow { get; set; }

        public AggregationDefinition Aggregation { get; set; }
    }
}
