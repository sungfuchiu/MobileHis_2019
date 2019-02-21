namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180327 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemLog", "Action", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SystemLog", "Action");
        }
    }
}
