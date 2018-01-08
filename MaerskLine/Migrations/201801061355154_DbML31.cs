namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbML31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ships", "ShipRoute", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ships", "ShipRoute");
        }
    }
}
