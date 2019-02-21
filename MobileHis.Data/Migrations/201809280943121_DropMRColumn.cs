namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMRColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecord", "OpdRegisterId", "dbo.OpdRegister");
            DropForeignKey("dbo.OpdRegister", "OpdRecordID", "dbo.OpdRecord");
            DropIndex("dbo.OpdRegister", new[] { "OpdRecordID" });
            DropIndex("dbo.MedicalRecord", new[] { "OpdRegisterId" });
            DropColumn("dbo.MedicalRecord", "ICD10_1");
            DropColumn("dbo.MedicalRecord", "ICD10_2");
            DropColumn("dbo.MedicalRecord", "ICD10_3");
            DropColumn("dbo.MedicalRecord", "ICD10_4");
            DropColumn("dbo.MedicalRecord", "OpdRegisterId");
        }

        public override void Down()
        {
            AddColumn("dbo.MedicalRecord", "OpdRegisterId", c => c.Int());
            AddColumn("dbo.MedicalRecord", "ICD10_4", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_3", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_2", c => c.String());
            AddColumn("dbo.MedicalRecord", "ICD10_1", c => c.String());
            AlterColumn("dbo.OpdRegister", "MedicalRecordId", c => c.Int(nullable: false));
            CreateIndex("dbo.OpdRegister", "OpdRecordID");
            AddForeignKey("dbo.OpdRegister", "OpdRecordID", "dbo.OpdRecord", "ID");
            AddForeignKey("dbo.MedicalRecord", "OpdRegisterId", "dbo.OpdRegister", "ID");
        }
    }
}
