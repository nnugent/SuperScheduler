namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "PositionID" });
            CreateIndex("dbo.Employees", "PositionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "PositionId" });
            CreateIndex("dbo.Employees", "PositionID");
        }
    }
}
