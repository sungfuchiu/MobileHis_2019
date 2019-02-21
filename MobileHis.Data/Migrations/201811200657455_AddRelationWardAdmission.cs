namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationWardAdmission : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PatientAdmissionForm", "WardId");
            CreateIndex("dbo.PatientAdmissionForm", "Ward2RoomId");
            AddForeignKey("dbo.PatientAdmissionForm", "WardId", "dbo.Ward", "ID");
            AddForeignKey("dbo.PatientAdmissionForm", "Ward2RoomId", "dbo.Ward2Room", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientAdmissionForm", "Ward2RoomId", "dbo.Ward2Room");
            DropForeignKey("dbo.PatientAdmissionForm", "WardId", "dbo.Ward");
            DropIndex("dbo.PatientAdmissionForm", new[] { "Ward2RoomId" });
            DropIndex("dbo.PatientAdmissionForm", new[] { "WardId" });
        }
    }
}
