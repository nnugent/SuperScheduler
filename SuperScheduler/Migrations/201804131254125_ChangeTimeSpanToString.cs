namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTimeSpanToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.Time(nullable: false, precision: 7));
        }
    }
}
