namespace HuynhDatHung_Lab456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        Follwer_Id = c.String(nullable: false, maxLength: 128),
                        Follwee_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Follwer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Follwee_Id)
                .Index(t => t.Follwer_Id)
                .Index(t => t.Follwee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Follwee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "Follwer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Follwee_Id" });
            DropIndex("dbo.Followings", new[] { "Follwer_Id" });
            DropTable("dbo.Followings");
        }
    }
}
