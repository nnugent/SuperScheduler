namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddedOvertimeLimitToOneWeekSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OvertimeLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shifts", "ScheduleSettings_Id", c => c.Int());
            AddColumn("dbo.OneWeekSchedules", "OvertimeLimit", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "ScheduleSettings_Id");
            AddForeignKey("dbo.Shifts", "ScheduleSettings_Id", "dbo.ScheduleSettings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ScheduleSettings_Id", "dbo.ScheduleSettings");
            DropIndex("dbo.Shifts", new[] { "ScheduleSettings_Id" });
            DropColumn("dbo.OneWeekSchedules", "OvertimeLimit");
            DropColumn("dbo.Shifts", "ScheduleSettings_Id");
            DropTable("dbo.ScheduleSettings");
        }
    }
}
