namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInAdmissionForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissionForm", "NewbornWeight_OZ", c => c.String(maxLength: 10));
            AddColumn("dbo.PatientAdmissionForm", "WeeksOfGestation", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissionForm", "WeeksOfGestation");
            DropColumn("dbo.PatientAdmissionForm", "NewbornWeight_OZ");
        }
    }
}
