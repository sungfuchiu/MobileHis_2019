namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmissionForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientAdmissionForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientID = c.String(maxLength: 12),
                        AdmissionDate = c.DateTime(nullable: false),
                        RoomId = c.Int(),
                        Bed = c.Int(),
                        AdmittingPhysican = c.String(maxLength: 50),
                        AdmitFrom_ER = c.Boolean(),
                        AdmitFrom_AD = c.Boolean(),
                        DischCashier = c.String(maxLength: 50),
                        NewbornWeight = c.String(maxLength: 10),
                        IncomeLevel = c.String(maxLength: 20),
                        Discharge_Dismissed = c.Boolean(),
                        Discharge_LeftAgainst = c.Boolean(),
                        Discharge_Death24 = c.Boolean(),
                        Discharge_Death48 = c.Boolean(),
                        DischargeDate = c.DateTime(),
                        DischargeTotalDay = c.Int(),
                        AutopsyPerformed = c.Boolean(),
                        CaseOfDeath_A = c.String(maxLength: 200),
                        CaseOfDeath_B = c.String(maxLength: 200),
                        CaseOfDeath_C = c.String(maxLength: 200),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patient", t => t.PatientID)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.PatientID)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.PatientFinalDiagnosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdmissionFormId = c.Int(nullable: false),
                        DiagnosisNumber = c.String(maxLength: 10),
                        Diagnosis = c.String(maxLength: 200),
                        ConditionOnDischarge = c.String(maxLength: 10),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientAdmissionForm", t => t.AdmissionFormId)
                .Index(t => t.AdmissionFormId);
            
            CreateTable(
                "dbo.PatientOperativeProcedure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdmissionFormId = c.Int(nullable: false),
                        OperatopmNo = c.String(maxLength: 10),
                        OperativeProcedure = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Is_PO_Infaceion = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientAdmissionForm", t => t.AdmissionFormId)
                .Index(t => t.AdmissionFormId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientAdmissionForm", "RoomId", "dbo.Room");
            DropForeignKey("dbo.PatientAdmissionForm", "PatientID", "dbo.Patient");
            DropForeignKey("dbo.PatientOperativeProcedure", "AdmissionFormId", "dbo.PatientAdmissionForm");
            DropForeignKey("dbo.PatientFinalDiagnosis", "AdmissionFormId", "dbo.PatientAdmissionForm");
            DropIndex("dbo.PatientOperativeProcedure", new[] { "AdmissionFormId" });
            DropIndex("dbo.PatientFinalDiagnosis", new[] { "AdmissionFormId" });
            DropIndex("dbo.PatientAdmissionForm", new[] { "RoomId" });
            DropIndex("dbo.PatientAdmissionForm", new[] { "PatientID" });
            DropTable("dbo.PatientOperativeProcedure");
            DropTable("dbo.PatientFinalDiagnosis");
            DropTable("dbo.PatientAdmissionForm");
        }
    }
}
