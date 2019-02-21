namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipPatient : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Patient", "Birth_Country");
            CreateIndex("dbo.Patient", "Birth_Atoll");
            CreateIndex("dbo.Patient", "Marshall_Zone");
            CreateIndex("dbo.Patient", "Marshall_Village");
            CreateIndex("dbo.Patient", "Marshall_Atoll");
            CreateIndex("dbo.Patient", "Country");
            CreateIndex("dbo.Patient", "StateCityAtoll");
            AddForeignKey("dbo.Patient", "Birth_Atoll", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "Birth_Country", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "Country", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "Marshall_Atoll", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "Marshall_Village", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "Marshall_Zone", "dbo.CodeFile", "ID");
            AddForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Marshall_Zone", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Marshall_Village", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Marshall_Atoll", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Country", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Birth_Country", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Birth_Atoll", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "StateCityAtoll" });
            DropIndex("dbo.Patient", new[] { "Country" });
            DropIndex("dbo.Patient", new[] { "Marshall_Atoll" });
            DropIndex("dbo.Patient", new[] { "Marshall_Village" });
            DropIndex("dbo.Patient", new[] { "Marshall_Zone" });
            DropIndex("dbo.Patient", new[] { "Birth_Atoll" });
            DropIndex("dbo.Patient", new[] { "Birth_Country" });
        }
    }
}
