namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billinglog_add_remark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingLog", "remark", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillingLog", "remark");
        }
    }
}
