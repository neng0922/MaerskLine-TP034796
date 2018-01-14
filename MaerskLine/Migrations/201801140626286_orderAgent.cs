namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderAgent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderAgent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderAgent");
        }
    }
}
