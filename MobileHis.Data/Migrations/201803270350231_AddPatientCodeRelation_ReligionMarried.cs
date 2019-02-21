namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientCodeRelation_ReligionMarried : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "ReligionId", c => c.Int());
            CreateIndex("dbo.Patient", "Married");
            CreateIndex("dbo.Patient", "ReligionId");
            AddForeignKey("dbo.Patient", "Married", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "ReligionId", "dbo.CodeFile", "ID");
            DropColumn("dbo.Patient", "Religion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient", "Religion", c => c.String(maxLength: 30));
            DropForeignKey("dbo.Patient", "ReligionId", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Married", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "ReligionId" });
            DropIndex("dbo.Patient", new[] { "Married" });
            DropColumn("dbo.Patient", "ReligionId");
        }
    }
}
