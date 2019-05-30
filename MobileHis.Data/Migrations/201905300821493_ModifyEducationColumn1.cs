namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEducationColumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HealthEdu", "QueueMsg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HealthEdu", "QueueMsg");
        }
    }
}
