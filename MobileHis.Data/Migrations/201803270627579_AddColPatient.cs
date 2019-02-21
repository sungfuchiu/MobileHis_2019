namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Race", c => c.Int());
            AddColumn("dbo.Patient", "PovertyLevel", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "PovertyLevel");
            DropColumn("dbo.Patient", "Race");
        }
    }
}
