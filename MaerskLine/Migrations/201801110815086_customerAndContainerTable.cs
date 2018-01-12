namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerAndContainerTable : DbMigration
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
                    })
                .PrimaryKey(t => t.ContainerID);
            
            AddColumn("dbo.Customers", "CustPhoneNum", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustEmail", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustAgent", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ContainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustName", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "ContainerID");
            AddForeignKey("dbo.Customers", "ContainerID", "dbo.Containers", "ContainerID", cascadeDelete: true);
            DropColumn("dbo.Customers", "custGender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "custGender", c => c.String());
            DropForeignKey("dbo.Customers", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Customers", new[] { "ContainerID" });
            AlterColumn("dbo.Customers", "CustName", c => c.String());
            DropColumn("dbo.Customers", "ContainerID");
            DropColumn("dbo.Customers", "CustAgent");
            DropColumn("dbo.Customers", "CustEmail");
            DropColumn("dbo.Customers", "CustPhoneNum");
            DropTable("dbo.Containers");
        }
    }
}
