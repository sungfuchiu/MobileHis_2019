namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientWeto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Household_Weto", c => c.Int());
            CreateIndex("dbo.Patient", "Household_Weto");
            AddForeignKey("dbo.Patient", "Household_Weto", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "Household_Weto", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "Household_Weto" });
            DropColumn("dbo.Patient", "Household_Weto");
        }
    }
}
