namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatetimeColumnForHook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodeFile", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.DrugVendor", "ModDate", c => c.DateTime());
            AlterColumn("dbo.Vendor", "ModDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendor", "ModDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DrugVendor", "ModDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CodeFile", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
