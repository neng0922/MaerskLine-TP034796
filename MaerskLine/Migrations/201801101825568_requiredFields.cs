namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "orderCustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "orderDetail", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "ScheduleOrigin", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "ScheduleDestination", c => c.String(nullable: false));
            AlterColumn("dbo.Ships", "ShipName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ships", "ShipName", c => c.String());
            AlterColumn("dbo.Schedules", "ScheduleDestination", c => c.String());
            AlterColumn("dbo.Schedules", "ScheduleOrigin", c => c.String());
            AlterColumn("dbo.Orders", "orderDetail", c => c.String());
            AlterColumn("dbo.Orders", "orderCustomerName", c => c.String());
        }
    }
}
