namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChagnedShiftToTimeSpan : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE ShiftLengths DROP CONSTRAINT DF__ShiftLeng__Shift__47DBAE45");
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftLengths", "Shift", c => c.DateTime(nullable: false));
        }
    }
}
