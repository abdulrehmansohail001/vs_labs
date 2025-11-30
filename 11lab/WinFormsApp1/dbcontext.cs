using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;    
namespace WinFormsApp1
{
    public class SmartMartContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleRecord> SalesRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V9NA7TM\SQLEXPRESS;Initial Catalog=lab11;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True;");
        }
    }
}
