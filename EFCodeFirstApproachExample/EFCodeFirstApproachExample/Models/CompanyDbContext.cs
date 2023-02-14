using EFCodeFirstApproachExample.Migrations;
using System.Data.Entity;

namespace EFCodeFirstApproachExample.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}