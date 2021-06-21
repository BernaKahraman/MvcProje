namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent_update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "Rate1", c => c.Int(nullable: false));
            AddColumn("dbo.Talents", "Rate2", c => c.Int(nullable: false));
            AddColumn("dbo.Talents", "Rate3", c => c.Int(nullable: false));
            AddColumn("dbo.Talents", "Rate4", c => c.Int(nullable: false));
            AddColumn("dbo.Talents", "Rate5", c => c.Int(nullable: false));
            DropColumn("dbo.Talents", "ImagePath");
            DropColumn("dbo.Talents", "TalentName");
            DropColumn("dbo.Talents", "Skill6");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talents", "Skill6", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "TalentName", c => c.String(maxLength: 20));
            AddColumn("dbo.Talents", "ImagePath", c => c.String(maxLength: 100));
            DropColumn("dbo.Talents", "Rate5");
            DropColumn("dbo.Talents", "Rate4");
            DropColumn("dbo.Talents", "Rate3");
            DropColumn("dbo.Talents", "Rate2");
            DropColumn("dbo.Talents", "Rate1");
        }
    }
}
