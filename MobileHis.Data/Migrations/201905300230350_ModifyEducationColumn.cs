namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEducationColumn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HealthEdu", new[] { "Guardian_Type_CodeFile" });
            DropIndex("dbo.HealthEdu_File", new[] { "Guardian_ID" });
            RenameColumn(table: "dbo.HealthEdu", name: "Guardian_Type_CodeFile", newName: "CodeFile_ID");
            AddColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile", c => c.Int(nullable: false));
            AddColumn("dbo.HealthEdu", "HealthEdu_Name", c => c.String(maxLength: 50));
            AddColumn("dbo.HealthEdu_File", "HealthEdu_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.HealthEdu", "CodeFile_ID", c => c.Int());
            AlterColumn("dbo.HealthEdu_File", "Guardian_ID", c => c.Int());
            CreateIndex("dbo.HealthEdu", "CodeFile_ID");
            CreateIndex("dbo.HealthEdu_File", "Guardian_ID");
            DropColumn("dbo.HealthEdu", "Guardian_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HealthEdu", "Guardian_Name", c => c.String(maxLength: 50));
            DropIndex("dbo.HealthEdu_File", new[] { "Guardian_ID" });
            DropIndex("dbo.HealthEdu", new[] { "CodeFile_ID" });
            AlterColumn("dbo.HealthEdu_File", "Guardian_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.HealthEdu", "CodeFile_ID", c => c.Int(nullable: false));
            DropColumn("dbo.HealthEdu_File", "HealthEdu_ID");
            DropColumn("dbo.HealthEdu", "HealthEdu_Name");
            DropColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile");
            RenameColumn(table: "dbo.HealthEdu", name: "CodeFile_ID", newName: "Guardian_Type_CodeFile");
            CreateIndex("dbo.HealthEdu_File", "Guardian_ID");
            CreateIndex("dbo.HealthEdu", "Guardian_Type_CodeFile");
        }
    }
}
