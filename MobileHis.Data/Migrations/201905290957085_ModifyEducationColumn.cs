namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEducationColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HealthEdu", name: "Guardian_Type_CodeFile", newName: "HealthEdu_Type_CodeFile");
            RenameColumn(table: "dbo.HealthEdu_File", name: "Guardian_ID", newName: "HealthEdu_ID");
            RenameIndex(table: "dbo.HealthEdu", name: "IX_Guardian_Type_CodeFile", newName: "IX_HealthEdu_Type_CodeFile");
            RenameIndex(table: "dbo.HealthEdu_File", name: "IX_Guardian_ID", newName: "IX_HealthEdu_ID");
            AddColumn("dbo.HealthEdu", "HealthEdu_Name", c => c.String(maxLength: 50));
            DropColumn("dbo.HealthEdu", "Guardian_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HealthEdu", "Guardian_Name", c => c.String(maxLength: 50));
            DropColumn("dbo.HealthEdu", "HealthEdu_Name");
            RenameIndex(table: "dbo.HealthEdu_File", name: "IX_HealthEdu_ID", newName: "IX_Guardian_ID");
            RenameIndex(table: "dbo.HealthEdu", name: "IX_HealthEdu_Type_CodeFile", newName: "IX_Guardian_Type_CodeFile");
            RenameColumn(table: "dbo.HealthEdu_File", name: "HealthEdu_ID", newName: "Guardian_ID");
            RenameColumn(table: "dbo.HealthEdu", name: "HealthEdu_Type_CodeFile", newName: "Guardian_Type_CodeFile");
        }
    }
}
