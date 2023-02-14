namespace EFCodeFirstApproachExample.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ToPopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Categories (CategoryName) VALUES ('Electronics')" +
                 "INSERT INTO Categories (CategoryName) VALUES ('Home Appliances')"
                );
        }

        public override void Down()
        {
        }
    }
}
