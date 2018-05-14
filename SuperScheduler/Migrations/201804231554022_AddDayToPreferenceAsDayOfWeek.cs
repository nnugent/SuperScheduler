namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayToPreferenceAsDayOfWeek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "Day");
        }
    }
}
