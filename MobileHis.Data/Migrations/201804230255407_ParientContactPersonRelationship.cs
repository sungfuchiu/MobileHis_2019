namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParientContactPersonRelationship : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "ContactPersonRelationship", c => c.Int());
            CreateIndex("dbo.Patient", "ContactPersonRelationship");
            AddForeignKey("dbo.Patient", "ContactPersonRelationship", "dbo.CodeFile", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "ContactPersonRelationship", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "ContactPersonRelationship" });
            AlterColumn("dbo.Patient", "ContactPersonRelationship", c => c.String());
        }
    }
}
