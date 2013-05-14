namespace ManagementTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKTeamID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TeamID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Employees", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
            CreateIndex("dbo.Employees", "TeamID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "TeamID" });
            DropForeignKey("dbo.Employees", "TeamID", "dbo.Teams");
            DropColumn("dbo.Employees", "TeamID");
        }
    }
}
