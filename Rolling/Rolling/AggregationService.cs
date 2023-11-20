using Rolling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Rolling
{
    public class AggregationService
    {
        public IEnumerable<Input> YearAggregate(Input.AggregationDefinition aggregation, IEnumerable<Input> inputs)
        {
            var result = new List<Input>();
            var yearGrouped = inputs.GroupBy(x => x.Date.Year);

            foreach (var group in yearGrouped)
            {
                result.Add(new Input()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = new DateTime(group.FirstOrDefault()!.Date.Year, 1, 1),
                    AggregatedValue = Aggregate(group, aggregation),
                });
            }

            return result;
        }

        public double Aggregate(IEnumerable<Input> Inputs, Input.AggregationDefinition aggregation)
        {
            switch (aggregation)
            {
                case Input.AggregationDefinition.Sum:
                    return Inputs.Sum(x => x.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(aggregation), aggregation, null);
            }
        }
    }
}
