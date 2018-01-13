namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContainerItemString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Containers", "ContainerItem", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Containers", "ContainerItem", c => c.Int(nullable: false));
        }
    }
}
