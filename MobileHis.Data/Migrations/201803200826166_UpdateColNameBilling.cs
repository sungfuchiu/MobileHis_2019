namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColNameBilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingItemLog", "DailyFee", c => c.Double());
            DropColumn("dbo.BillingItemLog", "SucceedingFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillingItemLog", "SucceedingFee", c => c.Double());
            DropColumn("dbo.BillingItemLog", "DailyFee");
        }
    }
}
