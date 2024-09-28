namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subtasks", "ST_Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Tasks", "T_Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "T_Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Subtasks", "ST_Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
