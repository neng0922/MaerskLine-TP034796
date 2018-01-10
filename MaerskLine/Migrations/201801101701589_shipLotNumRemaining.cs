namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipLotNumRemaining : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ships", "ShipLotNumRemaining", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ships", "ShipLotNumRemaining");
        }
    }
}
