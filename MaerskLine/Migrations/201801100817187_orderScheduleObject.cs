namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderScheduleObject : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "ScheduleID");
            AddForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules", "ScheduleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules");
            DropIndex("dbo.Orders", new[] { "ScheduleID" });
        }
    }
}
