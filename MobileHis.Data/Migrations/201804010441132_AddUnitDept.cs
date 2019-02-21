namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dept", "UnitId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dept", "UnitId");
        }
    }
}
