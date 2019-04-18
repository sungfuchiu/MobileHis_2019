namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordTypeInOpdRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpdRecord", "RecordType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpdRecord", "RecordType");
        }
    }
}
