namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeysToPreference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Preferences", "ShiftLength_Id", "dbo.ShiftLengths");
            DropForeignKey("dbo.Preferences", "StartTime_Id", "dbo.ShiftStartTimes");
            DropIndex("dbo.Preferences", new[] { "ShiftLength_Id" });
            DropIndex("dbo.Preferences", new[] { "StartTime_Id" });
            DropColumn("dbo.Preferences", "ShiftLengthId");
            DropColumn("dbo.Preferences", "StartTimeId");
            RenameColumn(table: "dbo.Preferences", name: "ShiftLength_Id", newName: "ShiftLengthId");
            RenameColumn(table: "dbo.Preferences", name: "StartTime_Id", newName: "StartTimeId");
            AlterColumn("dbo.Preferences", "StartTimeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Preferences", "ShiftLengthId", c => c.Int(nullable: false));
            AlterColumn("dbo.Preferences", "ShiftLengthId", c => c.Int(nullable: false));
            AlterColumn("dbo.Preferences", "StartTimeId", c => c.Int(nullable: false));
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
            AlterColumn("dbo.Preferences", "StartTimeId", c => c.Int());
            AlterColumn("dbo.Preferences", "ShiftLengthId", c => c.Int());
            AlterColumn("dbo.Preferences", "ShiftLengthId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Preferences", "StartTimeId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Preferences", name: "StartTimeId", newName: "StartTime_Id");
            RenameColumn(table: "dbo.Preferences", name: "ShiftLengthId", newName: "ShiftLength_Id");
            AddColumn("dbo.Preferences", "StartTimeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Preferences", "ShiftLengthId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Preferences", "StartTime_Id");
            CreateIndex("dbo.Preferences", "ShiftLength_Id");
            AddForeignKey("dbo.Preferences", "StartTime_Id", "dbo.ShiftStartTimes", "Id");
            AddForeignKey("dbo.Preferences", "ShiftLength_Id", "dbo.ShiftLengths", "Id");
        }
    }
}
