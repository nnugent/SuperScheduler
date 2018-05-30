namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOvertimeLimitToOneWeekSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OneWeekSchedules", "OvertimeLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OneWeekSchedules", "OvertimeLimit");
        }
    }
}
