namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingItemLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicalRecordID = c.Int(nullable: false),
                        ItemName = c.String(),
                        InitialFee = c.Double(),
                        SucceedingFee = c.Double(),
                        CreateAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Billing", t => t.MedicalRecordID)
                .Index(t => t.MedicalRecordID);
            
            AddColumn("dbo.DrugCost", "InitialFee", c => c.Double());
            AddColumn("dbo.DrugCost", "SucceedingFee", c => c.Double());
            AddColumn("dbo.Billing", "IsLocal", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingItemLog", "MedicalRecordID", "dbo.Billing");
            DropIndex("dbo.BillingItemLog", new[] { "MedicalRecordID" });
            DropColumn("dbo.Billing", "IsLocal");
            DropColumn("dbo.DrugCost", "SucceedingFee");
            DropColumn("dbo.DrugCost", "InitialFee");
            DropTable("dbo.BillingItemLog");
        }
    }
}
