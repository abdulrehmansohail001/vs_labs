namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new SmartMartContext())
            {
                context.Customers.AddRange(
                    new Customer { Name = "Ali", City = "Lahore" },
                    new Customer { Name = "Sara", City = "Karachi" },
                    new Customer { Name = "John", City = "Islamabad" }
                );

                context.Products.AddRange(
                    new Product { ProductName = "Laptop", Category = "Electronics" },
                    new Product { ProductName = "Mouse", Category = "Electronics" },
                    new Product { ProductName = "Shampoo", Category = "Cosmetics" },
                    new Product { ProductName = "Biscuits", Category = "Grocery" }
                );

                context.SaveChanges();

                context.SalesRecords.AddRange(
                    new SaleRecord { CustomerId = 1, ProductId = 1, SaleDate = DateTime.Now.AddDays(-1) },
                    new SaleRecord { CustomerId = 1, ProductId = 2, SaleDate = DateTime.Now.AddDays(-2) },
                    new SaleRecord { CustomerId = 2, ProductId = 3, SaleDate = DateTime.Now.AddDays(-3) },
                    new SaleRecord { CustomerId = 2, ProductId = 4, SaleDate = DateTime.Now.AddDays(-4) },
                    new SaleRecord { CustomerId = 1, ProductId = 3, SaleDate = DateTime.Now.AddDays(-5) }
                );

                context.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SmartMartContext())
            {
                var result =
                    from c in context.Customers
                    join s in context.SalesRecords on c.CustomerId equals s.CustomerId
                    join p in context.Products on s.ProductId equals p.ProductId
                    select new
                    {
                        CustomerName = c.Name,
                        c.City,
                        ProductName = p.ProductName,
                        s.SaleDate
                    };

                dataGridView1.DataSource = result.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new SmartMartContext())
            {
                var result =
                    from c in context.Customers
                    join s in context.SalesRecords on c.CustomerId equals s.CustomerId into salesGroup
                    from sg in salesGroup.DefaultIfEmpty()
                    join p in context.Products on sg.ProductId equals p.ProductId into productGroup
                    from pg in productGroup.DefaultIfEmpty()
                    select new
                    {
                        CustomerName = c.Name,
                        c.City,
                        ProductName = (pg != null ? pg.ProductName : "No Purchase")
                    };

                dataGridView1.DataSource = result.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new SmartMartContext())
            {
                var result =
                    from c in context.Customers
                    join s in context.SalesRecords on c.CustomerId equals s.CustomerId into salesGroup
                    select new
                    {
                        CustomerName = c.Name,
                        TotalPurchasedProducts = salesGroup.Count()
                    };

                dataGridView1.DataSource = result.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new SmartMartContext())
            {
                var result =
                    from p in context.Products
                    join s in context.SalesRecords on p.ProductId equals s.ProductId
                    group s by p.Category into g
                    select new
                    {
                        Category = g.Key,
                        TotalSales = g.Count()
                    };

                dataGridView1.DataSource = result.ToList();
            }
        }
    }
}
