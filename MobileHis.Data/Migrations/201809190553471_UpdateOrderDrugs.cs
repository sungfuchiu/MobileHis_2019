namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDrugs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDrug", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDrug", "Remark", c => c.String(nullable: false));
        }
    }
}
