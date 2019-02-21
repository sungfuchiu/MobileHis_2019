namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMedicalRecord1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "Diarrhea", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "ILI", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "Prolonged_Fever", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "AFR", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalRecord", "NoneAll", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalRecord", "NoneAll");
            DropColumn("dbo.MedicalRecord", "AFR");
            DropColumn("dbo.MedicalRecord", "Prolonged_Fever");
            DropColumn("dbo.MedicalRecord", "ILI");
            DropColumn("dbo.MedicalRecord", "Diarrhea");
        }
    }
}
