namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migwriterrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "WriterRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "WriterRole");
        }
    }
}
