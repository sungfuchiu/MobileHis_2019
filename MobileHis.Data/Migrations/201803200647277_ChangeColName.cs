namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugCost", "DailyFee", c => c.Double());
            DropColumn("dbo.DrugCost", "SucceedingFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugCost", "SucceedingFee", c => c.Double());
            DropColumn("dbo.DrugCost", "DailyFee");
        }
    }
}
