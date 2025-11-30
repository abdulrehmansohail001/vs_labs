using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string Category { get; set; }

        public ICollection<SaleRecord>? Sales { get; set; }
    }
}
