namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Nextkin_StateCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile");
            DropIndex("dbo.Patient", new[] { "StateCityAtoll" });
            DropColumn("dbo.Patient", "NextOfKinAddress");
            DropColumn("dbo.Patient", "NextOfKinAddressZipcode");
            DropColumn("dbo.Patient", "StateCityAtoll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient", "StateCityAtoll", c => c.Int());
            AddColumn("dbo.Patient", "NextOfKinAddressZipcode", c => c.String(maxLength: 5));
            AddColumn("dbo.Patient", "NextOfKinAddress", c => c.String(maxLength: 300));
            CreateIndex("dbo.Patient", "StateCityAtoll");
            AddForeignKey("dbo.Patient", "StateCityAtoll", "dbo.CodeFile", "ID");
        }
    }
}
