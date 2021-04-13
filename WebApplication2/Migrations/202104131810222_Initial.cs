namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hoppies",
                c => new
                    {
                        HoppyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.HoppyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonHoppy",
                c => new
                    {
                        PersonRefId = c.Int(nullable: false),
                        HoppyRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonRefId, t.HoppyRefId })
                .ForeignKey("dbo.People", t => t.PersonRefId, cascadeDelete: true)
                .ForeignKey("dbo.Hoppies", t => t.HoppyRefId, cascadeDelete: true)
                .Index(t => t.PersonRefId)
                .Index(t => t.HoppyRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonHoppy", "HoppyRefId", "dbo.Hoppies");
            DropForeignKey("dbo.PersonHoppy", "PersonRefId", "dbo.People");
            DropIndex("dbo.PersonHoppy", new[] { "HoppyRefId" });
            DropIndex("dbo.PersonHoppy", new[] { "PersonRefId" });
            DropTable("dbo.PersonHoppy");
            DropTable("dbo.People");
            DropTable("dbo.Hoppies");
        }
    }
}
