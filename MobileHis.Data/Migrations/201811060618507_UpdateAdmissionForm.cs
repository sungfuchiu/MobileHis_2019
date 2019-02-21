namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdmissionForm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientAdmissionForm", "AdmittingPhysican", c => c.Int());
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_A", c => c.String(maxLength: 20));
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_B", c => c.String(maxLength: 20));
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_C", c => c.String(maxLength: 20));
            AlterColumn("dbo.PatientFinalDiagnosis", "Diagnosis", c => c.String(maxLength: 10));
            DropColumn("dbo.PatientAdmissionForm", "IncomeLevel");
            DropColumn("dbo.PatientAdmissionForm", "DischargeTotalDay");
            DropColumn("dbo.PatientFinalDiagnosis", "DiagnosisNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientFinalDiagnosis", "DiagnosisNumber", c => c.String(maxLength: 10));
            AddColumn("dbo.PatientAdmissionForm", "DischargeTotalDay", c => c.Int());
            AddColumn("dbo.PatientAdmissionForm", "IncomeLevel", c => c.String(maxLength: 20));
            AlterColumn("dbo.PatientFinalDiagnosis", "Diagnosis", c => c.String(maxLength: 200));
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_C", c => c.String(maxLength: 200));
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_B", c => c.String(maxLength: 200));
            AlterColumn("dbo.PatientAdmissionForm", "CaseOfDeath_A", c => c.String(maxLength: 200));
            AlterColumn("dbo.PatientAdmissionForm", "AdmittingPhysican", c => c.String(maxLength: 50));
        }
    }
}
