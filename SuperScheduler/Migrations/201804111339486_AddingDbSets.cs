namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDbSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShiftStart = c.DateTime(nullable: false),
                        ShiftEnd = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreferedShift = c.DateTime(),
                        Name = c.String(),
                        Day_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .Index(t => t.Day_Id);
            
            CreateTable(
                "dbo.OneWeekSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShiftLengths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShiftStartTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TwoWeekSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Day_Id", "dbo.Days");
            DropIndex("dbo.Employees", new[] { "Day_Id" });
            DropTable("dbo.TwoWeekSchedules");
            DropTable("dbo.ShiftStartTimes");
            DropTable("dbo.ShiftLengths");
            DropTable("dbo.Positions");
            DropTable("dbo.OneWeekSchedules");
            DropTable("dbo.Employees");
            DropTable("dbo.Days");
        }
    }
}
