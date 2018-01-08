namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbMLorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderID = c.Int(nullable: false, identity: true),
                        custName = c.String(),
                        orderDetail = c.String(),
                        orderLotNum = c.Int(nullable: false),
                        orderDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.orderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
