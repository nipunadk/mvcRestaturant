namespace GreenRestaturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaturants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaturantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestaturantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaturants", t => t.RestaturantId, cascadeDelete: true)
                .Index(t => t.RestaturantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaturantReviews", "RestaturantId", "dbo.Restaturants");
            DropIndex("dbo.RestaturantReviews", new[] { "RestaturantId" });
            DropTable("dbo.RestaturantReviews");
            DropTable("dbo.Restaturants");
        }
    }
}
