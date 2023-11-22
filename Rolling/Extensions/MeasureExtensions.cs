using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rolling.Models;

namespace Rolling.Extensions
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
