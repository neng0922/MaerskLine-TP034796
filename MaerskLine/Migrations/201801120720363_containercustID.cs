namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class containercustID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Containers", "Customer_CustID", "dbo.Customers");
            DropIndex("dbo.Containers", new[] { "Customer_CustID" });
            RenameColumn(table: "dbo.Containers", name: "Customer_CustID", newName: "CustID");
            AlterColumn("dbo.Containers", "CustID", c => c.Int(nullable: false));
            CreateIndex("dbo.Containers", "CustID");
            AddForeignKey("dbo.Containers", "CustID", "dbo.Customers", "CustID", cascadeDelete: true);
            DropColumn("dbo.Containers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Containers", "CustomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Containers", "CustID", "dbo.Customers");
            DropIndex("dbo.Containers", new[] { "CustID" });
            AlterColumn("dbo.Containers", "CustID", c => c.Int());
            RenameColumn(table: "dbo.Containers", name: "CustID", newName: "Customer_CustID");
            CreateIndex("dbo.Containers", "Customer_CustID");
            AddForeignKey("dbo.Containers", "Customer_CustID", "dbo.Customers", "CustID");
        }
    }
}
