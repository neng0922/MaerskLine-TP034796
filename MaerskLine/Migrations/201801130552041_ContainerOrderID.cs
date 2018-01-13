namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContainerOrderID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Containers", "CustID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Containers", new[] { "CustID" });
            DropIndex("dbo.Orders", new[] { "ContainerID" });
            AddColumn("dbo.Containers", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Customer_CustID", c => c.Int());
            CreateIndex("dbo.Containers", "OrderID");
            CreateIndex("dbo.Orders", "Customer_CustID");
            AddForeignKey("dbo.Orders", "Customer_CustID", "dbo.Customers", "CustID");
            AddForeignKey("dbo.Containers", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            DropColumn("dbo.Containers", "CustID");
            DropColumn("dbo.Orders", "ContainerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ContainerID", c => c.Int(nullable: false));
            AddColumn("dbo.Containers", "CustID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Containers", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustID" });
            DropIndex("dbo.Containers", new[] { "OrderID" });
            DropColumn("dbo.Orders", "Customer_CustID");
            DropColumn("dbo.Orders", "CustomerID");
            DropColumn("dbo.Containers", "OrderID");
            CreateIndex("dbo.Orders", "ContainerID");
            CreateIndex("dbo.Containers", "CustID");
            AddForeignKey("dbo.Orders", "ContainerID", "dbo.Containers", "ContainerID", cascadeDelete: true);
            AddForeignKey("dbo.Containers", "CustID", "dbo.Customers", "CustID", cascadeDelete: true);
        }
    }
}
