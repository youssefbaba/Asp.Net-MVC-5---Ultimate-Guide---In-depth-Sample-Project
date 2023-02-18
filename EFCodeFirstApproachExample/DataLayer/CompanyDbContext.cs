using DomainModels;
using System.Data.Entity;

namespace DataLayer
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public CompanyDbContext() : base("MyConnectionString")
        {
        }
    }
}