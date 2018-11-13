namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                 INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'b05898b3-f558-412a-b27d-ac8f5fe48f0e', N'admin@vidly.com', 0, N'AOK4qoTLxpT1TX9Z6TbypYa9OiKhNBbFpMCHpm5wdfBD+upwe6ItS17vbYi2Hm9Wig==', N'09c4b522-77fc-4413-aab3-22dec5b3652b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                 INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'fe8079f5-364f-4e87-bd61-ab4fae132d2d', N'efremt@gmail.com', 0, N'AEA3E0x0kSECOqa8jX5rzLHTLETxsoSksg8FHEDUSH/aSlIGJdHyP/UK8Lwbh1otVw==', N'765be9e1-feb0-485d-97c6-521685542f5f', NULL, 0, 0, NULL, 1, 0, N'efremt@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a3104200-81ea-4dba-aed2-e4aa8dcc9092', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b05898b3-f558-412a-b27d-ac8f5fe48f0e', N'a3104200-81ea-4dba-aed2-e4aa8dcc9092')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
