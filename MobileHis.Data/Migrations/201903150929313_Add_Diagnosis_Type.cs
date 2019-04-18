namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Diagnosis_Type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpdRecord2ICD10", "DiagnosisType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpdRecord2ICD10", "DiagnosisType");
        }
    }
}
