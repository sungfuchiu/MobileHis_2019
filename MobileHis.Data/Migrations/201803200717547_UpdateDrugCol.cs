namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDrugCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug", "PatientFromType", c => c.Int());
            DropColumn("dbo.Drug", "IsLocal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drug", "IsLocal", c => c.Boolean());
            DropColumn("dbo.Drug", "PatientFromType");
        }
    }
}
