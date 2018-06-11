namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayValuesToShiftObjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShiftLengths", "Display", c => c.Boolean(nullable: false));
            AddColumn("dbo.ShiftStartTimes", "Display", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShiftStartTimes", "Display");
            DropColumn("dbo.ShiftLengths", "Display");
        }
    }
}
