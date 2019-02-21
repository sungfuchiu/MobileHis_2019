namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MedicalRecord", new[] { "Dept_ID" });
            DropIndex("dbo.OpdRecord", new[] { "PatinetId" });

            RenameColumn("dbo.MedicalRecord", "Dept_ID", "DeptId");
            RenameColumn("dbo.OpdRecord", "PatinetId", "PatientID");

            CreateIndex("dbo.MedicalRecord", "DeptId");
            CreateIndex("dbo.OpdRecord", "PatientID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OpdRecord", new[] { "PatientID" });
            DropIndex("dbo.MedicalRecord", new[] { "DeptId" });

            RenameColumn("dbo.MedicalRecord", "DeptId", "Dept_ID");
            RenameColumn("dbo.OpdRecord", "PatientID", "PatinetId");

            CreateIndex("dbo.OpdRecord", "PatientId");
            CreateIndex("dbo.MedicalRecord", "DeptID");
        }
    }
}
