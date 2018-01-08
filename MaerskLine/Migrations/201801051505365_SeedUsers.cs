namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'25604b75-f7c2-4d55-9636-d73be3558a3e', N'admin@ml.com', 0, N'AJUxhYGBtX3A6pueQYgY9kgrTO1+nvujnSSUDMYu/mTbWDC8pRA+jnN9kr7vEC7Prg==', N'ad718918-2187-490c-a4e8-08d51b57b36b', NULL, 0, 0, NULL, 1, 0, N'admin@ml.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f5254cc1-1acc-4e53-b476-8e032a4e9621', N'agent1@ml.com', 0, N'APJhMTBFjiwUgqTF+1C5hkSrBoeMFcjDjxoxegujuiJ+MPu3kyjIq87fZAn42jn4Sw==', N'8504e965-12e8-4f81-91e4-e1791393d9f6', NULL, 0, 0, NULL, 1, 0, N'agent1@ml.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4fcacf3e-6e07-4def-a5a8-ae9bf5cad58b', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25604b75-f7c2-4d55-9636-d73be3558a3e', N'4fcacf3e-6e07-4def-a5a8-ae9bf5cad58b')

");
        }
        
        public override void Down()
        {
        }
    }
}
