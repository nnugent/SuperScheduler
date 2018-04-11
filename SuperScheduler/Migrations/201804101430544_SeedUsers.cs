namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'510e52f5-3235-443a-b43b-ae8d51a3da60', N'manager@superscheduler.com', 0, N'AP89txHhLHXygIypixDK/XdMyY+mZY34bHB2Ya7E0ZZbVxYQ6GHQA8MA2cjsAx2eTw==', N'73d67448-c90d-44f9-8088-61c162ac56bb', NULL, 0, 0, NULL, 1, 0, N'manager@superscheduler.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'96cc10e3-b015-4b7c-9a88-d339340d5c24', N'employee@superscheduler.com', 0, N'ACdGJpaiBDf4NqXS8ACnwhAseXeqtTOLOwwd5JnjKSbKy51XpA8ZMqZAuYwAOj29PA==', N'0cc17e07-5474-4b6e-9454-4c6de86ce6c3', NULL, 0, 0, NULL, 1, 0, N'employee@superscheduler.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f9b8d637-d9fb-4a73-acde-e0239dfdbb53', N'CanManageSchedule')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'510e52f5-3235-443a-b43b-ae8d51a3da60', N'f9b8d637-d9fb-4a73-acde-e0239dfdbb53')
");
        }
        
        public override void Down()
        {
        }
    }
}
