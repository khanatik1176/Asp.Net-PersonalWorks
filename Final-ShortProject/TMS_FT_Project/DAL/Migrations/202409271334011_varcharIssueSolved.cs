namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class varcharIssueSolved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subtasks", "ST_Name", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Subtasks", "ST_Description", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tasks", "T_Name", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Tasks", "T_Description", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tasks", "T_Status", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "T_Status", c => c.String());
            AlterColumn("dbo.Tasks", "T_Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tasks", "T_Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Subtasks", "ST_Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Subtasks", "ST_Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
