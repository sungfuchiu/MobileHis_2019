namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpdRecordHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpdRecordHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OpdRecordId = c.Int(nullable: false),
                        HistoryJson = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OpdRecord", t => t.OpdRecordId)
                .Index(t => t.OpdRecordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpdRecordHistory", "OpdRecordId", "dbo.OpdRecord");
            DropIndex("dbo.OpdRecordHistory", new[] { "OpdRecordId" });
            DropTable("dbo.OpdRecordHistory");
        }
    }
}
