namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWardColumnInAdmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissionForm", "WardId", c => c.Int());
            AddColumn("dbo.PatientAdmissionForm", "Ward2RoomId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissionForm", "Ward2RoomId");
            DropColumn("dbo.PatientAdmissionForm", "WardId");
        }
    }
}
