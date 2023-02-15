namespace EFCodeFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAvailabilityStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String());
        }
    }
}
