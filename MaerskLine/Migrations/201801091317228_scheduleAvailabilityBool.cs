namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleAvailabilityBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "ScheduleAvailability", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "ScheduleAvailability", c => c.String());
        }
    }
}
