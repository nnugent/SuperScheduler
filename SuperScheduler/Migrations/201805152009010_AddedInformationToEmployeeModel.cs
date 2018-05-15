namespace SuperScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInformationToEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String());
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String());
            AddColumn("dbo.Employees", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Active");
            DropColumn("dbo.Employees", "PhoneNumber");
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
