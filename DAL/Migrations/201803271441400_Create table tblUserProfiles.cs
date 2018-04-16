namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatetabletblUserProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.String(maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserProfiles", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblUserProfiles", new[] { "Id" });
            DropTable("dbo.tblUserProfiles");
        }
    }
}
