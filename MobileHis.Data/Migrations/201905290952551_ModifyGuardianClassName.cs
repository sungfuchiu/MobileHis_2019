namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGuardianClassName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Guardian", newName: "HealthEdu");
            RenameTable(name: "dbo.Guardian_File", newName: "HealthEdu_File");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HealthEdu_File", newName: "Guardian_File");
            RenameTable(name: "dbo.HealthEdu", newName: "Guardian");
        }
    }
}
