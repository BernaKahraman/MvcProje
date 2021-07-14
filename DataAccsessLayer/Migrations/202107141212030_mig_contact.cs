namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactName", c => c.String(maxLength: 50));
            AddColumn("dbo.Contacts", "ContactMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "UserName");
            DropColumn("dbo.Contacts", "UserMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "ContactMail");
            DropColumn("dbo.Contacts", "ContactName");
        }
    }
}
