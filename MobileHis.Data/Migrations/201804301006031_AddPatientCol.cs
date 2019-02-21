namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Household_Text", c => c.String());
            AddColumn("dbo.Patient", "Household_Head", c => c.String(maxLength: 50));
            AddColumn("dbo.Patient", "Alab", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Alab");
            DropColumn("dbo.Patient", "Household_Head");
            DropColumn("dbo.Patient", "Household_Text");
        }
    }
}
