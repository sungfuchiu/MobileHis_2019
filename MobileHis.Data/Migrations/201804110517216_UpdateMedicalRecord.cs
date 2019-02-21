namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMedicalRecord : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MedicalRecord", new[] { "DeptID" });
            RenameColumn(table: "dbo.MedicalRecord", name: "DeptID", newName: "Dept_ID");
            AddColumn("dbo.MedicalRecord", "DeptName", c => c.String(nullable: false));
            AddColumn("dbo.MedicalRecord", "CallNo", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalRecord", "Dept_ID", c => c.Int());
            CreateIndex("dbo.MedicalRecord", "Dept_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MedicalRecord", new[] { "Dept_ID" });
            AlterColumn("dbo.MedicalRecord", "Dept_ID", c => c.Int(nullable: false)); 
            DropColumn("dbo.MedicalRecord", "CallNo");
            DropColumn("dbo.MedicalRecord", "DeptName");
            RenameColumn(table: "dbo.MedicalRecord", name: "Dept_ID", newName: "DeptID");
            CreateIndex("dbo.MedicalRecord", "DeptID");
        }
    }
}
