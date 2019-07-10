namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatetimeAndUserColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HealthEdu_File", "CreateDate", c => c.DateTime());
            AddColumn("dbo.SystemLog", "ModUser", c => c.String(maxLength: 20));
            DropColumn("dbo.HealthEdu_File", "UploadDate");
            DropColumn("dbo.SystemLog", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SystemLog", "User", c => c.String(maxLength: 20));
            AddColumn("dbo.HealthEdu_File", "UploadDate", c => c.DateTime());
            DropColumn("dbo.SystemLog", "ModUser");
            DropColumn("dbo.HealthEdu_File", "CreateDate");
        }
    }
}
