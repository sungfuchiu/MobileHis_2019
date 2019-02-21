namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSSOpdRegister : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OpdRegister", "Diarrhea");
            DropColumn("dbo.OpdRegister", "ILI");
            DropColumn("dbo.OpdRegister", "Prolonged_Fever");
            DropColumn("dbo.OpdRegister", "AFR");
            DropColumn("dbo.OpdRegister", "NoneAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpdRegister", "NoneAll", c => c.Boolean());
            AddColumn("dbo.OpdRegister", "AFR", c => c.Boolean());
            AddColumn("dbo.OpdRegister", "Prolonged_Fever", c => c.Boolean());
            AddColumn("dbo.OpdRegister", "ILI", c => c.Boolean());
            AddColumn("dbo.OpdRegister", "Diarrhea", c => c.Boolean());
        }
    }
}
