using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Models
{
    public static class MeasureExtensions
    {
        public static Measure SetAggregatedValue(this Measure measure, double aggregatedValue)
        {
            measure.AggregatedValue = aggregatedValue;
            return measure;
        }
    }
}
