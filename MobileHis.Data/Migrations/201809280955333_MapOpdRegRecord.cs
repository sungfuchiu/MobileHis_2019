namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapOpdRegRecord : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.OpdRegister", "MedicalRecordId", "dbo.MedicalRecord", "ID");

            CreateIndex("dbo.OpdRecord", "OpdRegisterId");
            AddForeignKey("dbo.OpdRecord", "OpdRegisterId", "dbo.OpdRegister", "ID");


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpdRecord", "OpdRegisterId", "dbo.OpdRegister");
            DropIndex("dbo.OpdRecord", new[] { "OpdRegisterId" });
            DropForeignKey("dbo.OpdRegister", "MedicalRecordId", "dbo.MedicalRecord");
        }
    }
}
