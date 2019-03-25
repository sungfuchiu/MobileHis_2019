namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatePatientColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "MRDTYPE", c => c.Int());
            AddColumn("dbo.Patient", "Title", c => c.Int());
            AddColumn("dbo.Patient", "Title_Eng", c => c.Int());
            AddColumn("dbo.Patient", "FirstName_Eng", c => c.String());
            AddColumn("dbo.Patient", "LastName_Eng", c => c.String());
            AddColumn("dbo.Patient", "MidName_Eng", c => c.String());
            AddColumn("dbo.Patient", "HnOther", c => c.Int());
            AddColumn("dbo.Patient", "Material", c => c.Int());
            AddColumn("dbo.Patient", "ResdentialType", c => c.Int());
            AddColumn("dbo.Patient", "ReceiveHospitalNews", c => c.Int());
            AddColumn("dbo.Patient", "PassportID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "PassportID");
            DropColumn("dbo.Patient", "ReceiveHospitalNews");
            DropColumn("dbo.Patient", "ResdentialType");
            DropColumn("dbo.Patient", "Material");
            DropColumn("dbo.Patient", "HnOther");
            DropColumn("dbo.Patient", "MidName_Eng");
            DropColumn("dbo.Patient", "LastName_Eng");
            DropColumn("dbo.Patient", "FirstName_Eng");
            DropColumn("dbo.Patient", "Title_Eng");
            DropColumn("dbo.Patient", "Title");
            DropColumn("dbo.Patient", "MRDTYPE");
        }
    }
}
