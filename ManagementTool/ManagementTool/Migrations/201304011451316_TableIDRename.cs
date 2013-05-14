namespace ManagementTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableIDRename : DbMigration
    {
        public override void Up()
        {
            
            DropPrimaryKey("dbo.Teams", new[] { "ID" });            
            DropPrimaryKey("dbo.Employees", new[] { "ID" });
            DropColumn("dbo.Teams", "ID");
            DropColumn("dbo.Employees", "ID");
            AddColumn("dbo.Teams", "TeamID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
            AddPrimaryKey("dbo.Teams", "TeamID");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teams", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employees", new[] { "EmployeeID" });
            AddPrimaryKey("dbo.Employees", "ID");
            DropPrimaryKey("dbo.Teams", new[] { "TeamID" });
            AddPrimaryKey("dbo.Teams", "ID");
            DropColumn("dbo.Employees", "EmployeeID");
            DropColumn("dbo.Teams", "TeamID");
        }
    }
}
