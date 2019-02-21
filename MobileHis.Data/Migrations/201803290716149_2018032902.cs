namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2018032902 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "PullOutDateTIme", c => c.DateTime());
            AddColumn("dbo.MedicalRecord", "PullInDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalRecord", "PullInDateTime");
            DropColumn("dbo.MedicalRecord", "PullOutDateTIme");
        }
    }
}
