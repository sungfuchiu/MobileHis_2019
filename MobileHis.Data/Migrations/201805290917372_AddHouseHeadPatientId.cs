namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHouseHeadPatientId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Household_Address", c => c.String(maxLength: 50));
            AddColumn("dbo.Patient", "Household_Head_PatientId", c => c.String(maxLength: 12));
            CreateIndex("dbo.Patient", "Household_Head_PatientId");
            AddForeignKey("dbo.Patient", "Household_Head_PatientId", "dbo.Patient", "PatientID");
            DropColumn("dbo.Patient", "Household_HospitalNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient", "Household_HospitalNo", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Patient", "Household_Head_PatientId", "dbo.Patient");
            DropIndex("dbo.Patient", new[] { "Household_Head_PatientId" });
            DropColumn("dbo.Patient", "Household_Head_PatientId");
            DropColumn("dbo.Patient", "Household_Address");
        }
    }
}
