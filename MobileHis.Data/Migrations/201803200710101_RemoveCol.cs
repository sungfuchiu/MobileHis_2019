namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecord", "InsuranceId", "dbo.CodeFile");
            DropIndex("dbo.MedicalRecord", new[] { "InsuranceId" });
            AddColumn("dbo.Billing", "PatientFrom", c => c.Int(nullable: false));
            DropColumn("dbo.MedicalRecord", "PatientFrom");
            DropColumn("dbo.MedicalRecord", "InsuranceId");
            DropColumn("dbo.Billing", "IsLocal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Billing", "IsLocal", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "InsuranceId", c => c.Int());
            AddColumn("dbo.MedicalRecord", "PatientFrom", c => c.Int(nullable: false));
            DropColumn("dbo.Billing", "PatientFrom");
            CreateIndex("dbo.MedicalRecord", "InsuranceId");
            AddForeignKey("dbo.MedicalRecord", "InsuranceId", "dbo.CodeFile", "ID");
        }
    }
}
