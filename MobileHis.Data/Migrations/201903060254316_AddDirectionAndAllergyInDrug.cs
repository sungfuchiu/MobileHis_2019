namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectionAndAllergyInDrug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug", "Allergy", c => c.String(maxLength: 500));
            AddColumn("dbo.Drug", "Direction", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drug", "Direction");
            DropColumn("dbo.Drug", "Allergy");
        }
    }
}
