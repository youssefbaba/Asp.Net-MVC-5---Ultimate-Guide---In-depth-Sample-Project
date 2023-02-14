namespace EFCodeFirstApproachExample.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ToPopulateBrands : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Brands (BrandName) VALUES ('Samsung')" +
                "INSERT INTO Brands (BrandName) VALUES ('Apple')" +
                "INSERT INTO Brands (BrandName) VALUES ('Sony')" +
                "INSERT INTO Brands (BrandName) VALUES ('Hp')"
                );
        }

        public override void Down()
        {
        }
    }
}
