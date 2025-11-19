using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labtask
{
    public class Employee
    {
        public int EmpId { get; set; }

        public required string Name { get; set; }
        public required string FatherName { get; set; }
        public required string CNIC { get; set; }

        public string? Designation { get; set; }

        public decimal Salary { get; set; }
        public required string Department { get; set; }

        public DateTime HireDate { get; set; }
    }
}
