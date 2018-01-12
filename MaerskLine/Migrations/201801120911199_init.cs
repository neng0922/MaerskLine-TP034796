namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerItem = c.Int(nullable: false),
                        ContainerNum = c.Int(nullable: false),
                        ContainerWeight = c.Double(nullable: false),
                        CustID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID)
                .ForeignKey("dbo.Customers", t => t.CustID, cascadeDelete: true)
                .Index(t => t.CustID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        CustName = c.String(nullable: false),
                        CustPhoneNum = c.String(nullable: false),
                        CustEmail = c.String(nullable: false),
                        CustAgent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDelivered = c.Boolean(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.ScheduleID)
                .Index(t => t.ContainerID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        ScheduleOrigin = c.String(nullable: false),
                        ScheduleDestination = c.String(nullable: false),
                        ScheduleDepartureDateTime = c.DateTime(nullable: false),
                        ScheduleArrivalDateTime = c.DateTime(nullable: false),
                        ScheduleAvailability = c.Boolean(nullable: false),
                        ShipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: true)
                .Index(t => t.ShipID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipContainerNum = c.Int(nullable: false),
                        ShipContainerNumRemaining = c.Int(nullable: false),
                        ShipAvailability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Orders", "ContainerID", "dbo.Containers");
            DropForeignKey("dbo.Containers", "CustID", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Schedules", new[] { "ShipID" });
            DropIndex("dbo.Orders", new[] { "ContainerID" });
            DropIndex("dbo.Orders", new[] { "ScheduleID" });
            DropIndex("dbo.Containers", new[] { "CustID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Containers");
        }
    }
}
