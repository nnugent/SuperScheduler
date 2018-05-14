namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePreferenceModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Preferences", "StartTimeId");
            CreateIndex("dbo.Preferences", "ShiftLengthId");
            AddForeignKey("dbo.Preferences", "ShiftLengthId", "dbo.ShiftLengths", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Preferences", "StartTimeId", "dbo.ShiftStartTimes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preferences", "StartTimeId", "dbo.ShiftStartTimes");
            DropForeignKey("dbo.Preferences", "ShiftLengthId", "dbo.ShiftLengths");
            DropIndex("dbo.Preferences", new[] { "ShiftLengthId" });
            DropIndex("dbo.Preferences", new[] { "StartTimeId" });
        }
    }
}
