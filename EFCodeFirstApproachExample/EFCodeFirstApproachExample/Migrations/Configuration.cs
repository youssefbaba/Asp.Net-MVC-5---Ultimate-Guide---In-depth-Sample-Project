namespace EFCodeFirstApproachExample.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirstApproachExample.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFCodeFirstApproachExample.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(
                new Models.Brand() { BrandID = 1, BrandName = "Samsung" },
                new Models.Brand() { BrandID = 2, BrandName = "Apple" },
                new Models.Brand() { BrandID = 3, BrandName = "Sony" },
                new Models.Brand() { BrandID = 4, BrandName = "HP" }
                );

            context.Categories.AddOrUpdate(
                new Models.Category() { CategoryID = 1, CategoryName = "Electronics" },
                new Models.Category() { CategoryID = 2, CategoryName = "Home Appliances" }
                );
        }
    }
}
