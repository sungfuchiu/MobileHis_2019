namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavoriteICD10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ICD10Favorites", "ICD10Code", "dbo.ICD10");
            DropIndex("dbo.ICD10Favorites", new[] { "ICD10Code" });
            DropColumn("dbo.OpdRecord2ICD10", "DiagnosisType");
            DropTable("dbo.ICD10Favorites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ICD10Favorites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD10Code = c.String(nullable: false, maxLength: 10),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.OpdRecord2ICD10", "DiagnosisType", c => c.Int(nullable: false));
            CreateIndex("dbo.ICD10Favorites", "ICD10Code");
            AddForeignKey("dbo.ICD10Favorites", "ICD10Code", "dbo.ICD10", "ICD10Code");
        }
    }
}
