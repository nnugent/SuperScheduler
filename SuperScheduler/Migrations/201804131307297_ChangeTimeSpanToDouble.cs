namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTimeSpanToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.String());
        }
    }
}
