namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderCustomerName", c => c.String());
            AddColumn("dbo.Orders", "orderDelivered", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "ScheduleID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "custName");
            DropColumn("dbo.Orders", "orderDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "orderDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "custName", c => c.String());
            DropColumn("dbo.Orders", "ScheduleID");
            DropColumn("dbo.Orders", "orderDelivered");
            DropColumn("dbo.Orders", "orderCustomerName");
        }
    }
}
