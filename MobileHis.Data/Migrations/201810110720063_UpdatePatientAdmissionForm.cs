namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientAdmissionForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissionForm", "AdmitFrom_OPD", c => c.Boolean());
            AddColumn("dbo.PatientAdmissionForm", "AdmitFrom_RHC", c => c.Boolean());
            AddColumn("dbo.PatientAdmissionForm", "AdmitFrom_MCH", c => c.Boolean());
            DropColumn("dbo.PatientAdmissionForm", "AdmitFrom_AD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientAdmissionForm", "AdmitFrom_AD", c => c.Boolean());
            DropColumn("dbo.PatientAdmissionForm", "AdmitFrom_MCH");
            DropColumn("dbo.PatientAdmissionForm", "AdmitFrom_RHC");
            DropColumn("dbo.PatientAdmissionForm", "AdmitFrom_OPD");
        }
    }
}
