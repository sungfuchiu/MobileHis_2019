namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceTitleIdToTitleAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "Title_id", "dbo.CodeFile");
            DropIndex("dbo.Account", new[] { "Title_id" });
            AddColumn("dbo.Account", "Title", c => c.String());
            DropColumn("dbo.Account", "Title_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "Title_id", c => c.Int());
            DropColumn("dbo.Account", "Title");
            CreateIndex("dbo.Account", "Title_id");
            AddForeignKey("dbo.Account", "Title_id", "dbo.CodeFile", "ID");
        }
    }
}
