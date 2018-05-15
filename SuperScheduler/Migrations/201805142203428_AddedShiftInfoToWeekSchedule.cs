namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShiftInfoToWeekSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShiftLengths", "OneWeekSchedule_Id", c => c.Int());
            AddColumn("dbo.ShiftStartTimes", "OneWeekSchedule_Id", c => c.Int());
            CreateIndex("dbo.ShiftLengths", "OneWeekSchedule_Id");
            CreateIndex("dbo.ShiftStartTimes", "OneWeekSchedule_Id");
            AddForeignKey("dbo.ShiftLengths", "OneWeekSchedule_Id", "dbo.OneWeekSchedules", "Id");
            AddForeignKey("dbo.ShiftStartTimes", "OneWeekSchedule_Id", "dbo.OneWeekSchedules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShiftStartTimes", "OneWeekSchedule_Id", "dbo.OneWeekSchedules");
            DropForeignKey("dbo.ShiftLengths", "OneWeekSchedule_Id", "dbo.OneWeekSchedules");
            DropIndex("dbo.ShiftStartTimes", new[] { "OneWeekSchedule_Id" });
            DropIndex("dbo.ShiftLengths", new[] { "OneWeekSchedule_Id" });
            DropColumn("dbo.ShiftStartTimes", "OneWeekSchedule_Id");
            DropColumn("dbo.ShiftLengths", "OneWeekSchedule_Id");
        }
    }
}
