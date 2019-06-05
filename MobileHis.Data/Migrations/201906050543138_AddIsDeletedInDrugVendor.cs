namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedInDrugVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugVendor", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.DrugVendor", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugVendor", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.DrugVendor", "IsDeleted");
        }
    }
}
