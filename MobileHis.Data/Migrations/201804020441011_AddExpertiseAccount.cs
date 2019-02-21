namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpertiseAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Expertise", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Expertise");
        }
    }
}
