namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "IsDraft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
        }
    }
}
