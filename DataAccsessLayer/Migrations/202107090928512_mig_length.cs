namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterRole", c => c.String());
        }
    }
}
