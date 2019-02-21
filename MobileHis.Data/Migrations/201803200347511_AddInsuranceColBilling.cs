namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceColBilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug", "IsLocal", c => c.Boolean());
            AddColumn("dbo.Billing", "InsuranceId", c => c.Int());
            CreateIndex("dbo.Billing", "InsuranceId");
            AddForeignKey("dbo.Billing", "InsuranceId", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billing", "InsuranceId", "dbo.CodeFile");
            DropIndex("dbo.Billing", new[] { "InsuranceId" });
            DropColumn("dbo.Billing", "InsuranceId");
            DropColumn("dbo.Drug", "IsLocal");
        }
    }
}
