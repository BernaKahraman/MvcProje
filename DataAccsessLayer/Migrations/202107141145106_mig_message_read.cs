namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_read : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "IsRead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageRead");
        }
    }
}
