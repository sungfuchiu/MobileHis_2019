namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "StateCityAtoll" });
            CreateTable(
                "dbo.ICD10Favorites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD10Code = c.String(nullable: false, maxLength: 10),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD10", t => t.ICD10Code)
                .Index(t => t.ICD10Code);
            
            AddColumn("dbo.Patient", "MRDTYPE", c => c.Int());
            AddColumn("dbo.Patient", "Title", c => c.Int());
            AddColumn("dbo.Patient", "Title_Eng", c => c.Int());
            AddColumn("dbo.Patient", "FirstName_Eng", c => c.String());
            AddColumn("dbo.Patient", "LastName_Eng", c => c.String());
            AddColumn("dbo.Patient", "MidName_Eng", c => c.String());
            AddColumn("dbo.Patient", "HnOther", c => c.Int());
            AddColumn("dbo.Patient", "Material", c => c.Int());
            AddColumn("dbo.Patient", "ResdentialType", c => c.Int());
            AddColumn("dbo.Patient", "Residential", c => c.String());
            AddColumn("dbo.Patient", "ReceiveHospitalNews", c => c.Int());
            AddColumn("dbo.Patient", "PassportID", c => c.String());
            AddColumn("dbo.OpdRecord2ICD10", "DiagnosisType", c => c.Int(nullable: false));
            AddColumn("dbo.Drug", "Allergy", c => c.String(maxLength: 500));
            AddColumn("dbo.Drug", "Direction", c => c.String(maxLength: 500));
            DropColumn("dbo.Patient", "NextOfKinAddress");
            DropColumn("dbo.Patient", "NextOfKinAddressZipcode");
            DropColumn("dbo.Patient", "StateCityAtoll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient", "StateCityAtoll", c => c.Int());
            AddColumn("dbo.Patient", "NextOfKinAddressZipcode", c => c.String(maxLength: 5));
            AddColumn("dbo.Patient", "NextOfKinAddress", c => c.String(maxLength: 300));
            DropForeignKey("dbo.ICD10Favorites", "ICD10Code", "dbo.ICD10");
            DropIndex("dbo.ICD10Favorites", new[] { "ICD10Code" });
            DropColumn("dbo.Drug", "Direction");
            DropColumn("dbo.Drug", "Allergy");
            DropColumn("dbo.OpdRecord2ICD10", "DiagnosisType");
            DropColumn("dbo.Patient", "PassportID");
            DropColumn("dbo.Patient", "ReceiveHospitalNews");
            DropColumn("dbo.Patient", "Residential");
            DropColumn("dbo.Patient", "ResdentialType");
            DropColumn("dbo.Patient", "Material");
            DropColumn("dbo.Patient", "HnOther");
            DropColumn("dbo.Patient", "MidName_Eng");
            DropColumn("dbo.Patient", "LastName_Eng");
            DropColumn("dbo.Patient", "FirstName_Eng");
            DropColumn("dbo.Patient", "Title_Eng");
            DropColumn("dbo.Patient", "Title");
            DropColumn("dbo.Patient", "MRDTYPE");
            DropTable("dbo.ICD10Favorites");
            CreateIndex("dbo.Patient", "StateCityAtoll");
            AddForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile", "ID");
        }
    }
}
