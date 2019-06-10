namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyVendorColumnNameForTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendor", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendor", "ModDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendor", "CreatedAt");
            DropColumn("dbo.Vendor", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendor", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Vendor", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendor", "ModDate");
            DropColumn("dbo.Vendor", "CreateDate");
        }
    }
}
