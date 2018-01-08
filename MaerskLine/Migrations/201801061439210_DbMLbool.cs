namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbMLbool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ships", "ShipAvailability", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ships", "ShipAvailability", c => c.String());
        }
    }
}
