namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddFormulationColToDrug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug", "Formulation", c => c.Int());
            AddColumn("dbo.Drug", "SubCategory", c => c.Int());
            DropColumn("dbo.OrderDrug", "Unit");
            DropColumn("dbo.DrugSetting", "Unit");
            DropColumn("dbo.OrderKit", "Unit");

             string[] subCatList =new string[]{ "ANALGESICS", "ANAESTHETICS", "ANTIBACTERIAL", "ANTIFUNGALS", "ANTIHELMINTICS", 
                "ANTITUBERCULOSIS AGENTS", "CENTRAL NERVOUS SYSTEM DRUGS", "CARDIOVASCULAR AGENTS", "CONTROLLED SUBSTANCES", "DERMATOLOGICAL AGENTS", 
                "EAR/NOSE/THROAT AGENTS", "ENDOCRINE & METABOLIC AGENTS", "EYE PREPARATION", "GASTROITESTINAL AGENTS", "GENITO-URINARY AGENTS", 
                "HEMATOLOGICAL AGENTS", "INJECTABLE NUTRITIONAL", "INTRAVENOUS FLUIDS", "Misc", "NUTRITIONAL AGENTS/VITAMINS", "OBGYN AGENTS", "RESPIRATORY AGENTS" };
             for (int i = 0; i < subCatList.Length;i++)
             {
                 Sql("insert into CodeFile (ItemType, ItemCode, ItemDescription, Remark, CreateDate, ModDate, ModUser) values('DC','"+i.ToString("D2")+"','"+subCatList[i]+"','',getdate(), getDate(), 'sys')");
             }
             SqlFile("./Sql/MigrateDrug.sql");
        }

        public override void Down()
        {
            AddColumn("dbo.OrderKit", "Unit", c => c.Int(nullable: false));
            AddColumn("dbo.DrugSetting", "Unit", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderDrug", "Unit", c => c.Int(nullable: false));
            DropColumn("dbo.Drug", "SubCategory");
            DropColumn("dbo.Drug", "Formulation");
        }
    }
}
