namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "ImagePath", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill1", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill2", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill3", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill4", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill5", c => c.String(maxLength: 100));
            AddColumn("dbo.Talents", "Skill6", c => c.String(maxLength: 100));
            DropColumn("dbo.Talents", "Percent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talents", "Percent", c => c.String());
            DropColumn("dbo.Talents", "Skill6");
            DropColumn("dbo.Talents", "Skill5");
            DropColumn("dbo.Talents", "Skill4");
            DropColumn("dbo.Talents", "Skill3");
            DropColumn("dbo.Talents", "Skill2");
            DropColumn("dbo.Talents", "Skill1");
            DropColumn("dbo.Talents", "ImagePath");
        }
    }
}
