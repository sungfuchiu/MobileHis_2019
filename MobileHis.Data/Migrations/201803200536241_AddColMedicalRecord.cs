namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColMedicalRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "PatientFrom", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalRecord", "InsuranceId", c => c.Int());
            CreateIndex("dbo.MedicalRecord", "InsuranceId");
            AddForeignKey("dbo.MedicalRecord", "InsuranceId", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecord", "InsuranceId", "dbo.CodeFile");
            DropIndex("dbo.MedicalRecord", new[] { "InsuranceId" });
            DropColumn("dbo.MedicalRecord", "InsuranceId");
            DropColumn("dbo.MedicalRecord", "PatientFrom");
        }
    }
}
