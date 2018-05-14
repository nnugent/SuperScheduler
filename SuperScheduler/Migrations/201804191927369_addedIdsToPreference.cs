namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIdsToPreference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "StartTimeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Preferences", "ShiftLengthId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "ShiftLengthId");
            DropColumn("dbo.Preferences", "StartTimeId");
        }
    }
}
