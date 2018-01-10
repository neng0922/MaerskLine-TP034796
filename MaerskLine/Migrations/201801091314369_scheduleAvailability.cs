namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "ScheduleAvailability", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "ScheduleAvailability");
        }
    }
}
