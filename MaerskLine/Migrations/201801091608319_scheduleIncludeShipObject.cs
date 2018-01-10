namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleIncludeShipObject : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Schedules", "ShipID");
            AddForeignKey("dbo.Schedules", "ShipID", "dbo.Ships", "ShipID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ShipID", "dbo.Ships");
            DropIndex("dbo.Schedules", new[] { "ShipID" });
        }
    }
}
