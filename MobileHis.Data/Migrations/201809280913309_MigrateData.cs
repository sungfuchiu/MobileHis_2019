namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateData : DbMigration
    {
        public override void Up()
        {
            SqlFile("./Sql/MigrateData.sql");
            //System.Threading.Thread.Sleep(3 * 60 * 1000);
        }
        
        public override void Down()
        {
        }
    }
}
