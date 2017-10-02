namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a98851e8-b5a3-478f-821f-19722fe2db85', N'ahmadfaiq1@gmail.com', 0, N'AK0XZw2HLjDtjaQ2QfN3/GvFNcG8EGv8NfYJ0bUDogDaG7ZmCO8e+hopjgjvxM+UwA==', N'b501d670-1942-4aa3-a3d9-0f8ef8c3da2f', NULL, 0, 0, NULL, 1, 0, N'ahmadfaiq1@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f9a0434c-0aa5-4194-b167-91b703eece47', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a98851e8-b5a3-478f-821f-19722fe2db85', N'f9a0434c-0aa5-4194-b167-91b703eece47')

");
        }
        
        public override void Down()
        {
        }
    }
}
