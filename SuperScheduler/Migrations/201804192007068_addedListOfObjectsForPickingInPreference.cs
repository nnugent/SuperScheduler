namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedListOfObjectsForPickingInPreference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Preferences", "ShiftLengthId", "dbo.ShiftLengths");
            DropForeignKey("dbo.Preferences", "StartTimeId", "dbo.ShiftStartTimes");
            DropIndex("dbo.Preferences", new[] { "StartTimeId" });
            DropIndex("dbo.Preferences", new[] { "ShiftLengthId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Preferences", "ShiftLengthId");
            CreateIndex("dbo.Preferences", "StartTimeId");
            AddForeignKey("dbo.Preferences", "StartTimeId", "dbo.ShiftStartTimes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Preferences", "ShiftLengthId", "dbo.ShiftLengths", "Id", cascadeDelete: true);
        }
    }
}
