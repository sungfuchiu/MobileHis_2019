namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicalrecord_callno_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalRecord", "CallNo", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalRecord", "CallNo", c => c.Int(nullable: false));
        }
    }
}
