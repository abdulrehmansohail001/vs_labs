using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }

        public ICollection<SaleRecord>? Sales { get; set; }
    }
}
