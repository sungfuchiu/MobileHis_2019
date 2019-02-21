namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "POBOXNo", c => c.String(maxLength: 100));
            AddColumn("dbo.Patient", "Landmark", c => c.String(maxLength: 100));
            AddColumn("dbo.Patient", "Longitude", c => c.Single());
            AddColumn("dbo.Patient", "Latitude", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Latitude");
            DropColumn("dbo.Patient", "Longitude");
            DropColumn("dbo.Patient", "Landmark");
            DropColumn("dbo.Patient", "POBOXNo");
        }
    }
}
