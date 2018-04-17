namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPositionToIncludeNameInsteadOfPositionList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "Name");
        }
    }
}
