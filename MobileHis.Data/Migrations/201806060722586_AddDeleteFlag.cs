namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeleteFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalRecord", "IsDeleted");
        }
    }
}
