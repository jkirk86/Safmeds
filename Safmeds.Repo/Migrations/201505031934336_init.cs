namespace Safmeds.Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Safmeds",
                c => new
                    {
                        SafmedId = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Topic = c.String(),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.SafmedId);
            
            CreateTable(
                "dbo.SafmedSessions",
                c => new
                    {
                        SafmedSessionId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        SessionTime = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                        Topic = c.String(),
                        Correct = c.Int(nullable: false),
                        NotYet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SafmedSessionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SafmedSessions");
            DropTable("dbo.Safmeds");
        }
    }
}
