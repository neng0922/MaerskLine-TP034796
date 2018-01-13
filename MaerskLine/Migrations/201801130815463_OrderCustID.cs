namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCustID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustID" });
            RenameColumn(table: "dbo.Orders", name: "Customer_CustID", newName: "CustID");
            AlterColumn("dbo.Orders", "CustID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustID");
            AddForeignKey("dbo.Orders", "CustID", "dbo.Customers", "CustID", cascadeDelete: true);
            DropColumn("dbo.Orders", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustID" });
            AlterColumn("dbo.Orders", "CustID", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CustID", newName: "Customer_CustID");
            CreateIndex("dbo.Orders", "Customer_CustID");
            AddForeignKey("dbo.Orders", "Customer_CustID", "dbo.Customers", "CustID");
        }
    }
}
