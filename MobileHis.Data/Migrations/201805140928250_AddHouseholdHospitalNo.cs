namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHouseholdHospitalNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Household_HospitalNo", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Household_HospitalNo");
        }
    }
}
