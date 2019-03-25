namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatePatientColumn2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Residential", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Residential");
        }
    }
}
