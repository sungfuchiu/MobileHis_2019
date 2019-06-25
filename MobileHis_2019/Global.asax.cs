using MobileHis_2019.Filters;
using System;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MobileHis_2019
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Register();
            ModelBinders.Binders[typeof(IPrincipal)] = new IPrincipalModelBinder();
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpCookie langCookie = Request.Cookies["sysLang"];

            CultureInfo currentCulture = null;
            if (langCookie == null || String.IsNullOrWhiteSpace(langCookie.Value) || langCookie.Value == "null")
            {
                currentCulture = Thread.CurrentThread.CurrentCulture;
                HttpCookie newCookie = new HttpCookie("sysLang", currentCulture.Name);
                newCookie.Path = "/";
                newCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(newCookie);
            }
            else
                currentCulture = new CultureInfo(langCookie.Value);

            Thread.CurrentThread.CurrentUICulture = currentCulture;

            // server Culture run 在 Invariant culture下
            Thread.CurrentThread.CurrentCulture = new CultureInfo("");

            // 切換 datatimeFormate culture 但是 datetime 記算還是以西元Calander計算
            Thread.CurrentThread.CurrentCulture.DateTimeFormat = new CultureInfo(currentCulture.Name).DateTimeFormat;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = CultureInfo.InvariantCulture.Calendar;
        }
    }
}
