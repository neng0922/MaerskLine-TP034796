namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class containerCustomerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Customers", new[] { "ContainerID" });
            DropColumn("dbo.Customers", "ContainerID");
            DropTable("dbo.Containers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerItem = c.Int(nullable: false),
                        ContainerWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            AddColumn("dbo.Customers", "ContainerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "ContainerID");
            AddForeignKey("dbo.Customers", "ContainerID", "dbo.Containers", "ContainerID", cascadeDelete: true);
        }
    }
}
