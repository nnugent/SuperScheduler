namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionListToOneWeekSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "OneWeekSchedule_Id", c => c.Int());
            CreateIndex("dbo.Positions", "OneWeekSchedule_Id");
            AddForeignKey("dbo.Positions", "OneWeekSchedule_Id", "dbo.OneWeekSchedules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "OneWeekSchedule_Id", "dbo.OneWeekSchedules");
            DropIndex("dbo.Positions", new[] { "OneWeekSchedule_Id" });
            DropColumn("dbo.Positions", "OneWeekSchedule_Id");
        }
    }
}
