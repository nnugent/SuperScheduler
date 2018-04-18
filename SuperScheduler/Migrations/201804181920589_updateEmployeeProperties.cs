namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Day_Id", "dbo.Days");
            DropIndex("dbo.Employees", new[] { "Day_Id" });
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToWork = c.Boolean(nullable: false),
                        Day = c.DateTime(nullable: false),
                        ShiftLength_Id = c.Int(),
                        StartTime_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShiftLengths", t => t.ShiftLength_Id)
                .ForeignKey("dbo.ShiftStartTimes", t => t.StartTime_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.ShiftLength_Id)
                .Index(t => t.StartTime_Id)
                .Index(t => t.Employee_Id);
            
            AddColumn("dbo.Employees", "MaxHours", c => c.Byte(nullable: false));
            DropColumn("dbo.Employees", "PreferedShift");
            DropColumn("dbo.Employees", "Day_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Day_Id", c => c.Int());
            AddColumn("dbo.Employees", "PreferedShift", c => c.DateTime());
            DropForeignKey("dbo.Preferences", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Preferences", "StartTime_Id", "dbo.ShiftStartTimes");
            DropForeignKey("dbo.Preferences", "ShiftLength_Id", "dbo.ShiftLengths");
            DropIndex("dbo.Preferences", new[] { "Employee_Id" });
            DropIndex("dbo.Preferences", new[] { "StartTime_Id" });
            DropIndex("dbo.Preferences", new[] { "ShiftLength_Id" });
            DropColumn("dbo.Employees", "MaxHours");
            DropTable("dbo.Preferences");
            CreateIndex("dbo.Employees", "Day_Id");
            AddForeignKey("dbo.Employees", "Day_Id", "dbo.Days", "Id");
        }
    }
}
