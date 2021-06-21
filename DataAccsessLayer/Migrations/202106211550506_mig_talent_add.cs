namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        About = c.String(maxLength: 50),
                        TalentName = c.String(maxLength: 20),
                        Percent = c.String(),
                    })
                .PrimaryKey(t => t.TalentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
