namespace ManagementTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Teams", "Name", c => c.String());
        }
    }
}
