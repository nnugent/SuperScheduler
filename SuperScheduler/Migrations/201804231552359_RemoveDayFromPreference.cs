namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDayFromPreference : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Preferences", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "Day", c => c.DateTime(nullable: false));
        }
    }
}
