namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserColumnForHook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugVendor", "ModUser", c => c.String());
            AddColumn("dbo.Vendor", "ModUser", c => c.String());
            AddColumn("dbo.Setting", "ModUser", c => c.String());
            AlterColumn("dbo.Account", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Account", "ModDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "ModDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Account", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Setting", "ModUser");
            DropColumn("dbo.Vendor", "ModUser");
            DropColumn("dbo.DrugVendor", "ModUser");
        }
    }
}
