namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeePositionIdToBeNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            AlterColumn("dbo.Employees", "PositionId", c => c.Int());
            CreateIndex("dbo.Employees", "PositionId");
            AddForeignKey("dbo.Employees", "PositionId", "dbo.Positions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            AlterColumn("dbo.Employees", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "PositionId");
            AddForeignKey("dbo.Employees", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
    }
}
