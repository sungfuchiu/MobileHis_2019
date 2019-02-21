namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        number = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
