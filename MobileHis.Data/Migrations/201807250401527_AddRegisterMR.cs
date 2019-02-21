namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterMR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecord", "OpdRegisterId", c => c.Int());
            CreateIndex("dbo.MedicalRecord", "OpdRegisterId");
            AddForeignKey("dbo.MedicalRecord", "OpdRegisterId", "dbo.OpdRegister", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecord", "OpdRegisterId", "dbo.OpdRegister");
            DropIndex("dbo.MedicalRecord", new[] { "OpdRegisterId" });
            DropColumn("dbo.MedicalRecord", "OpdRegisterId");
        }
    }
}
