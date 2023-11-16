using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Rolling
{
    public class SlidingWindowService
    {
        public enum BinDefinition { NotSet, Minute, Hour, Day, Week, Month, Trimester, Quarter, Semester, Year }

        public int? CalculateSlidingWindow(BinDefinition bin, BinDefinition win)
        {
            if (win < bin)
                return null;

            if (bin == BinDefinition.Semester)
            {
                switch (win)
                {
                    case BinDefinition.Year: return 2;
                }
            }

            if (bin == BinDefinition.Quarter)
            {
                switch (win)
                {
                    case BinDefinition.Year: return 3;
                }
            }

            if (bin == BinDefinition.Trimester)
            {
                switch (win)
                {
                    case BinDefinition.Year: return 4;
                }
            }

            if (bin == BinDefinition.Month)
            {
                switch (win)
                {
                    case BinDefinition.Quarter: return 3;
                    case BinDefinition.Trimester: return 4;
                    case BinDefinition.Semester: return 6;
                    case BinDefinition.Year: return 12;
                }
            }

            return null;
        }
    }
}
