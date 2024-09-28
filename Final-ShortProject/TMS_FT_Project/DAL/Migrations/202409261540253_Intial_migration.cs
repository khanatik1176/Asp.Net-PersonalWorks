namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subtasks",
                c => new
                    {
                        ST_id = c.Int(nullable: false, identity: true),
                        ST_Name = c.String(nullable: false, maxLength: 10),
                        ST_Description = c.String(nullable: false, maxLength: 50),
                        T_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ST_id)
                .ForeignKey("dbo.Tasks", t => t.T_id, cascadeDelete: true)
                .Index(t => t.T_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Tid = c.Int(nullable: false, identity: true),
                        T_Name = c.String(nullable: false, maxLength: 10),
                        T_Description = c.String(nullable: false, maxLength: 50),
                        T_Complete_Date = c.DateTime(nullable: false),
                        T_Status = c.String(),
                        UserEmail = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Tid)
                .ForeignKey("dbo.Users", t => t.UserEmail)
                .Index(t => t.UserEmail);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserEmail = c.String(nullable: false, maxLength: 128, unicode: false),
                        Uid = c.Int(nullable: false),
                        UserPassword = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Role = c.String(),
                        UD_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserEmail)
                .ForeignKey("dbo.UserDetails", t => t.UD_id, cascadeDelete: true)
                .Index(t => t.UD_id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UD_id = c.Int(nullable: false, identity: true),
                        UD_Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        UD_Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        UD_Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        UD_PhoneNumber = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.UD_id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        UserEmail = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserEmail)
                .Index(t => t.UserEmail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserEmail", "dbo.Users");
            DropForeignKey("dbo.Subtasks", "T_id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "UserEmail", "dbo.Users");
            DropForeignKey("dbo.Users", "UD_id", "dbo.UserDetails");
            DropIndex("dbo.Tokens", new[] { "UserEmail" });
            DropIndex("dbo.Users", new[] { "UD_id" });
            DropIndex("dbo.Tasks", new[] { "UserEmail" });
            DropIndex("dbo.Subtasks", new[] { "T_id" });
            DropTable("dbo.Tokens");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Subtasks");
        }
    }
}
