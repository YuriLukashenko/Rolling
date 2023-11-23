namespace Rolling.Data
{
    public class Enums
    {
        public enum BinDefinition { NotSet, Minute, Hour, Day, Week, Month, Quarter, Year }
        public enum TestDefinition
        {
            Accumulated,
            Rolling,
            Month,
            Quarter,
            YearByLastDate
        }
    }
}
