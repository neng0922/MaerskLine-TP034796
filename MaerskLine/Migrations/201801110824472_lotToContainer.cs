namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lotToContainer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderContainerNum", c => c.Int(nullable: false));
            AddColumn("dbo.Ships", "ShipContainerNum", c => c.Int(nullable: false));
            AddColumn("dbo.Ships", "ShipContainerNumRemaining", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "orderLotNum");
            DropColumn("dbo.Ships", "ShipLotNum");
            DropColumn("dbo.Ships", "ShipLotNumRemaining");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "ShipLotNumRemaining", c => c.Int(nullable: false));
            AddColumn("dbo.Ships", "ShipLotNum", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "orderLotNum", c => c.Int(nullable: false));
            DropColumn("dbo.Ships", "ShipContainerNumRemaining");
            DropColumn("dbo.Ships", "ShipContainerNum");
            DropColumn("dbo.Orders", "orderContainerNum");
        }
    }
}
