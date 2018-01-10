namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class splitShipAndSchedule2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        ScheduleOrigin = c.String(),
                        ScheduleDestination = c.String(),
                        ScheduleDepartureDateTime = c.DateTime(nullable: false),
                        ScheduleArrivalDateTime = c.DateTime(nullable: false),
                        ShipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
