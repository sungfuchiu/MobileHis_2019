namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyColumnNameInDrugVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugVendor", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DrugVendor", "ModDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.DrugVendor", "CreatedAt");
            DropColumn("dbo.DrugVendor", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugVendor", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.DrugVendor", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.DrugVendor", "ModDate");
            DropColumn("dbo.DrugVendor", "CreateDate");
        }
    }
}
