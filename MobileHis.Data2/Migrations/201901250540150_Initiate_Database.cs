namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiate_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugStock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DrugID = c.Guid(nullable: false),
                        Lot = c.String(maxLength: 20),
                        CurrentStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .Index(t => t.DrugID);
            
            AddColumn("dbo.DrugVendor", "PurchaseStockRate", c => c.String());
            AddColumn("dbo.PosTransactionD", "Lot", c => c.String(maxLength: 20));
            AlterColumn("dbo.DrugVendor", "StockUsingRate", c => c.String());
            DropColumn("dbo.Drug", "StockAmount");
            DropColumn("dbo.DrugVendor", "PurchaseRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugVendor", "PurchaseRate", c => c.Int(nullable: false));
            AddColumn("dbo.Drug", "StockAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.DrugStock", "DrugID", "dbo.Drug");
            DropIndex("dbo.DrugStock", new[] { "DrugID" });
            AlterColumn("dbo.DrugVendor", "StockUsingRate", c => c.Int(nullable: false));
            DropColumn("dbo.PosTransactionD", "Lot");
            DropColumn("dbo.DrugVendor", "PurchaseStockRate");
            DropTable("dbo.DrugStock");
        }
    }
}
