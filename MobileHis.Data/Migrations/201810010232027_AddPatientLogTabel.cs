namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientLogTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OldPatientID = c.String(maxLength: 50),
                        NewPatientID = c.String(maxLength: 50),
                        OldPatientName = c.String(maxLength: 160),
                        NewPatientName = c.String(maxLength: 160),
                        CreateBy = c.String(maxLength: 20),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientLog");
        }
    }
}
