using Microsoft.EntityFrameworkCore;
namespace T2203E_demo.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private const string connectionString = @"Data Source=DESKTOP-5GHA6RF\\SQLEXPRESS;Initial Catalog=T2203E-demo;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
