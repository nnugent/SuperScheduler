namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftModelAndUpdateOthers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShiftLength_Id = c.Int(),
                        ShiftStartTime_Id = c.Int(),
                        Day_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShiftLengths", t => t.ShiftLength_Id)
                .ForeignKey("dbo.ShiftStartTimes", t => t.ShiftStartTime_Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .Index(t => t.ShiftLength_Id)
                .Index(t => t.ShiftStartTime_Id)
                .Index(t => t.Day_Id);
            
            AddColumn("dbo.Days", "OneWeekSchedule_Id", c => c.Int());
            AddColumn("dbo.Employees", "OneWeekSchedule_Id", c => c.Int());
            CreateIndex("dbo.Days", "OneWeekSchedule_Id");
            CreateIndex("dbo.Employees", "OneWeekSchedule_Id");
            AddForeignKey("dbo.Employees", "OneWeekSchedule_Id", "dbo.OneWeekSchedules", "Id");
            AddForeignKey("dbo.Days", "OneWeekSchedule_Id", "dbo.OneWeekSchedules", "Id");
            DropColumn("dbo.Days", "ShiftStart");
            DropColumn("dbo.Days", "ShiftEnd");
            DropColumn("dbo.Days", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Days", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Days", "ShiftEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Days", "ShiftStart", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Days", "OneWeekSchedule_Id", "dbo.OneWeekSchedules");
            DropForeignKey("dbo.Employees", "OneWeekSchedule_Id", "dbo.OneWeekSchedules");
            DropForeignKey("dbo.Shifts", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.Shifts", "ShiftStartTime_Id", "dbo.ShiftStartTimes");
            DropForeignKey("dbo.Shifts", "ShiftLength_Id", "dbo.ShiftLengths");
            DropIndex("dbo.Employees", new[] { "OneWeekSchedule_Id" });
            DropIndex("dbo.Shifts", new[] { "Day_Id" });
            DropIndex("dbo.Shifts", new[] { "ShiftStartTime_Id" });
            DropIndex("dbo.Shifts", new[] { "ShiftLength_Id" });
            DropIndex("dbo.Days", new[] { "OneWeekSchedule_Id" });
            DropColumn("dbo.Employees", "OneWeekSchedule_Id");
            DropColumn("dbo.Days", "OneWeekSchedule_Id");
            DropTable("dbo.Shifts");
        }
    }
}
