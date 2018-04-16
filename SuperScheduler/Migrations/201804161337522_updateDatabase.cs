namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShiftStartTimes", "ShiftStartTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShiftStartTimes", "ShiftStartTime");
        }
    }
}
