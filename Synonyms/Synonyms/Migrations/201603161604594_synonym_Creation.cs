namespace Synonyms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class synonym_Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SynonymDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Term = c.String(),
                        Synonyms = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SynonymDtoes");
        }
    }
}
