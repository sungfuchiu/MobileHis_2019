namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyForeignKeyForHealthEdu : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HealthEdu", new[] { "CodeFile_ID" });
            DropIndex("dbo.HealthEdu_File", new[] { "Guardian_ID" });
            DropColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile");
            DropColumn("dbo.HealthEdu_File", "HealthEdu_ID");
            RenameColumn(table: "dbo.HealthEdu", name: "CodeFile_ID", newName: "HealthEdu_Type_CodeFile");
            RenameColumn(table: "dbo.HealthEdu_File", name: "Guardian_ID", newName: "HealthEdu_ID");
            AlterColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile", c => c.Int(nullable: false));
            AlterColumn("dbo.HealthEdu_File", "HealthEdu_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.HealthEdu", "HealthEdu_Type_CodeFile");
            CreateIndex("dbo.HealthEdu_File", "HealthEdu_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HealthEdu_File", new[] { "HealthEdu_ID" });
            DropIndex("dbo.HealthEdu", new[] { "HealthEdu_Type_CodeFile" });
            AlterColumn("dbo.HealthEdu_File", "HealthEdu_ID", c => c.Int());
            AlterColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile", c => c.Int());
            RenameColumn(table: "dbo.HealthEdu_File", name: "HealthEdu_ID", newName: "Guardian_ID");
            RenameColumn(table: "dbo.HealthEdu", name: "HealthEdu_Type_CodeFile", newName: "CodeFile_ID");
            AddColumn("dbo.HealthEdu_File", "HealthEdu_ID", c => c.Int(nullable: false));
            AddColumn("dbo.HealthEdu", "HealthEdu_Type_CodeFile", c => c.Int(nullable: false));
            CreateIndex("dbo.HealthEdu_File", "Guardian_ID");
            CreateIndex("dbo.HealthEdu", "CodeFile_ID");
        }
    }
}
