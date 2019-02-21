namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWardRelevantTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ward",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WardName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ward2Room",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WardId = c.Int(nullable: false),
                        Room = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ward2Room");
            DropTable("dbo.Ward");
        }
    }
}
