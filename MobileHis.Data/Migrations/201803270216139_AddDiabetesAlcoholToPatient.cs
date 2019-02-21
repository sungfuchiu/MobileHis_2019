namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiabetesAlcoholToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Diabetes", c => c.String(maxLength: 1));
            AddColumn("dbo.Patient", "Alcohol", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Alcohol");
            DropColumn("dbo.Patient", "Diabetes");
        }
    }
}
