namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class containers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerItem = c.Int(nullable: false),
                        ContainerWeight = c.Double(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Customer_CustID = c.Int(),
                    })
                .PrimaryKey(t => t.ContainerID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustID)
                .Index(t => t.Customer_CustID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "Customer_CustID", "dbo.Customers");
            DropIndex("dbo.Containers", new[] { "Customer_CustID" });
            DropTable("dbo.Containers");
        }
    }
}
