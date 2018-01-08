namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbML3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ships",
            c => new
            {
                ShipID = c.Int(nullable: false, identity: true),
                ShipName = c.String(),
                ShipLotNum = c.String(),
                ShipAvailability = c.String(),
            })
                .PrimaryKey(t => t.ShipID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Ships");
        }
    }
}
