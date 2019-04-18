namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddICD10FavoritesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ICD10Favorites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD10Code = c.String(nullable: false, maxLength: 10),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD10", t => t.ICD10Code)
                .Index(t => t.ICD10Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ICD10Favorites", "ICD10Code", "dbo.ICD10");
            DropIndex("dbo.ICD10Favorites", new[] { "ICD10Code" });
            DropTable("dbo.ICD10Favorites");
        }
    }
}
