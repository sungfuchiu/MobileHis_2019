namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAccountExpertiselength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Expertise", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "Expertise", c => c.String(maxLength: 200));
        }
    }
}
