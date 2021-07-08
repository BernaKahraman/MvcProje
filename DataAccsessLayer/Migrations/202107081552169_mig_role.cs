namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_role : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "WriterRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "WriterRole", c => c.String(maxLength: 1));
        }
    }
}
