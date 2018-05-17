namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPositionForeignKeyToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PositionId", c => c.Int(nullable: true));
            CreateIndex("dbo.Employees", "PositionId");
            AddForeignKey("dbo.Employees", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropColumn("dbo.Employees", "PositionId");
        }
    }
}
