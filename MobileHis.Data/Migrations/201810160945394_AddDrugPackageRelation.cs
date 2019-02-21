namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDrugPackageRelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderKit", "DrugID");
        }

        public override void Down()
        {
            DropIndex("dbo.OrderKit", new[] { "DrugID" });
        }
    }
}
