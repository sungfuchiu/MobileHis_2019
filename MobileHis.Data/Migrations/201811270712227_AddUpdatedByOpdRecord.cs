namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatedByOpdRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpdRecord", "UpdatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpdRecord", "UpdatedBy");
        }
    }
}
