namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPastHistory_FamilyHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "PastHistory", c => c.String());
            AddColumn("dbo.Patient", "FamilyHistory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "FamilyHistory");
            DropColumn("dbo.Patient", "PastHistory");
        }
    }
}
