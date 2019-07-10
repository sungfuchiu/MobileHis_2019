using MobileHis_2019.Routing;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings
{
    public class SettingsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Settings";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Vendor",
                "Settings/Vendor/Drug/{action}/{DrugID}",
                new { controller= "DrugVendor", action = "Index", DrugID = UrlParameter.Optional }
            );
            context.MapRoute(
                "Settings_default",
                "Settings/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = new NotEqual("DrugVendor") }
            );
        }
    }
}