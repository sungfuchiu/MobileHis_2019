using Autofac;
using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            // 第一步，建立ContainerBuilder
            var builder = new ContainerBuilder();

            // 開始 第二步，註冊service

            // 註冊ConsoleLogger這個class為ILogger Service的Component
            builder.RegisterType<DrugVendorBLL>.As<IDrugVendorBLL>();

            // 如果寫法是：builder.RegisterType<ConsoleLogger>(); 
            // 那麼就是ConsoleLogger這個class為ConsoleLogger Service的Component

            // 註冊自己實例化出來的物件
            // 上面是只註冊class type（因此，用到的時候是autofac幫你new出來），這邊是直接用這個object
            var output = new StringWriter();
            builder.RegisterInstance(output).As<TextWriter>();

            // 用lambda 註冊會更有彈性，因為傳進來的c是container的instance，因此可以用c來做一些複雜的東西。
            builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();

            // 假設不想要一個一個註冊，可以用scan的方式。
            // 下面scan一個assembly所有的type，當那個type的名字最後結尾是Repository的時候，
            // 把它註冊的service設為這個class的interface
            builder.RegisterAssemblyTypes(myAssembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces();

            //結束 第二步

            // 第三步，註冊都完成了，建立自己的container
            var container = builder.Build();

            // 第四部，從container取得對應的component。
            // 這邊用using包起來，因為出了這個scope，一切Resolve出來的都會被釋放掉。
            // 這部份在我們整個系列碰到並不多，因為不建議自己每一個這樣取出來，
            // 而是用深度整合的方式來讓一切像自動發生。
            // 詳細之後就會比較清楚
            using (var scope = container.BeginLifetimeScope())
            {
                var reader = container.Resolve<IConfigReader>();
            }
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
