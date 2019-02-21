namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newOPD : DbMigration
    {
        public override void Up()
        { 
            AddColumn("dbo.Dept", "Clinic", c => c.String(maxLength: 20));
            AddColumn("dbo.OpdRecord", "TempCreatedAt", c => c.DateTime());
            AddColumn("dbo.MedicalRecord", "VisitDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OpdRecord","OpdRegisterId",c=>c.Int());
            AddColumn("dbo.OpdRegister", "MedicalRecordId", c => c.Int());
            AddColumn("dbo.OpdRegister", "IsDeleted", c => c.Boolean(nullable: false));

            SqlFile("./Sql/UpdateOpdRegDataByDeptClinic.sql");
           

 //CreateIndex("dbo.OpdRegister", "MedicalRecordId");
            //CreateIndex("dbo.OpdRecord", "OpdRegisterId");
            //AddForeignKey("dbo.OpdRegister", "MedicalRecordId", "dbo.MedicalRecord", "ID");
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalRecord", "VisitDate");
            DropColumn("dbo.OpdRecord", "TempCreatedAt");
            DropColumn("dbo.OpdRegister", "IsDeleted");
            DropColumn("dbo.OpdRegister", "MedicalRecordId");
            DropColumn("dbo.Dept", "Clinic");
            DropColumn("dbo.OpdRecord", "OpdRegisterId");
        }
    }
}
