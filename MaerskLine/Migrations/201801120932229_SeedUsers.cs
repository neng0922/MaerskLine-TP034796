namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'36ffdbf8-beb4-4e80-abcc-83a97b3bb106', N'admin@ml.com', 0, N'AKqHGYacv5R9koWJY3mLLGT2B2i//Tme6da29O28/PYHwEosXDBqjJ4VMnTXAAjoUQ==', N'46901fac-68dd-49b8-a532-3a2291cee5d0', NULL, 0, 0, NULL, 1, 0, N'admin@ml.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8755ceab-cfec-4811-8f28-b370ce831dc5', N'agent1@ml.com', 0, N'AFY1L93hXFsCfmBN1++hydgXhHb5GOYmtJqguSC1V7DYkA5DT4N8gHMDyqgRDtVZ3g==', N'243fb791-6e30-4a3f-96f2-abf43a4e2744', NULL, 0, 0, NULL, 1, 0, N'agent1@ml.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'212b5a04-26ad-454b-bc52-88138bab46b6', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES (N'36ffdbf8-beb4-4e80-abcc-83a97b3bb106', N'212b5a04-26ad-454b-bc52-88138bab46b6')
");
        }
        
        public override void Down()
        {
        }
    }
}
