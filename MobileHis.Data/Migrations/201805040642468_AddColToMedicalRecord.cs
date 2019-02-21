namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColToMedicalRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "TriageTime", c => c.DateTime());
            AddColumn("dbo.MedicalRecord", "DoctorTime", c => c.DateTime());
            AddColumn("dbo.MedicalRecord", "Doctor", c => c.Int());
            AddColumn("dbo.MedicalRecord", "Admit", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "ICD10_1", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_2", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_3", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalRecord", "ICD10_4");
            DropColumn("dbo.MedicalRecord", "ICD10_3");
            DropColumn("dbo.MedicalRecord", "ICD10_2");
            DropColumn("dbo.MedicalRecord", "ICD10_1");
            DropColumn("dbo.MedicalRecord", "Admit");
            DropColumn("dbo.MedicalRecord", "Doctor");
            DropColumn("dbo.MedicalRecord", "DoctorTime");
            DropColumn("dbo.MedicalRecord", "TriageTime");
        }
    }
}
