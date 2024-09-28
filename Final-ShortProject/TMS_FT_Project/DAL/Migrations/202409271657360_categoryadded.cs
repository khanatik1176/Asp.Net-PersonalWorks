namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        C_Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.C_Name);
            
            AddColumn("dbo.Tasks", "C_Name", c => c.String(maxLength: 20, unicode: false));
            CreateIndex("dbo.Tasks", "C_Name");
            AddForeignKey("dbo.Tasks", "C_Name", "dbo.Categories", "C_Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "C_Name", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "C_Name" });
            DropColumn("dbo.Tasks", "C_Name");
            DropTable("dbo.Categories");
        }
    }
}
