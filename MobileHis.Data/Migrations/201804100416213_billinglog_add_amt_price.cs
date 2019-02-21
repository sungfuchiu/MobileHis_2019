namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billinglog_add_amt_price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingLog", "amt_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillingLog", "amt_price");
        }
    }
}
