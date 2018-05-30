namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScheduleSettings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OneWeekSchedules", "OvertimeLimit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OneWeekSchedules", "OvertimeLimit", c => c.Int(nullable: false));
        }
    }
}
