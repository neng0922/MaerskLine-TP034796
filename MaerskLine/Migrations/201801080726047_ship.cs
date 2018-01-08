namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ships", "ShipOrigin", c => c.String());
            AddColumn("dbo.Ships", "ShipDestination", c => c.String());
            AddColumn("dbo.Ships", "ShipDepartingTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ships", "ShipArrivingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ships", "ShipLotNum", c => c.Int(nullable: false));
            DropColumn("dbo.Ships", "ShipRoute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "ShipRoute", c => c.String());
            AlterColumn("dbo.Ships", "ShipLotNum", c => c.String());
            DropColumn("dbo.Ships", "ShipArrivingTime");
            DropColumn("dbo.Ships", "ShipDepartingTime");
            DropColumn("dbo.Ships", "ShipDestination");
            DropColumn("dbo.Ships", "ShipOrigin");
        }
    }
}
