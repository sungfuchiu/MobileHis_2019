namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentCodeFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodeFile", "ParentCodeFile", c => c.Int());
            CreateIndex("dbo.CodeFile", "ParentCodeFile");
            AddForeignKey("dbo.CodeFile", "ParentCodeFile", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodeFile", "ParentCodeFile", "dbo.CodeFile");
            DropIndex("dbo.CodeFile", new[] { "ParentCodeFile" });
            DropColumn("dbo.CodeFile", "ParentCodeFile");
        }
    }
}
