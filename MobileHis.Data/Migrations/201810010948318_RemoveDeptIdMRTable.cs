namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemoveDeptIdMRTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MedicalRecord", "IX_DeptId");
            DropForeignKey("dbo.MedicalRecord", "DeptId", "dbo.Dept");
            DropColumn("dbo.MedicalRecord", "DeptId");

        }

        public override void Down()
        {
            AddColumn("dbo.MedicalRecord", "DeptId", c => c.Int(true));
            CreateIndex("dbo.MedicalRecord", "DeptId");
           AddForeignKey("dbo.MedicalRecord", "DeptId", "dbo.Dept", "ID");

           
        }
    }
}
