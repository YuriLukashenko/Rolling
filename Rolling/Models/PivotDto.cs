using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Models
{
    public class PivotDto
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Function { get; set; }
        public decimal Salary { get; set; }
    }
}
