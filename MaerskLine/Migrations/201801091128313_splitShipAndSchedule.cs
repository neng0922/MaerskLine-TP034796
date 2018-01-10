namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class splitShipAndSchedule : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ships", "ShipOrigin");
            DropColumn("dbo.Ships", "ShipDestination");
            DropColumn("dbo.Ships", "ShipDepartingTime");
            DropColumn("dbo.Ships", "ShipArrivingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "ShipArrivingTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ships", "ShipDepartingTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ships", "ShipDestination", c => c.String());
            AddColumn("dbo.Ships", "ShipOrigin", c => c.String());
        }
    }
}
