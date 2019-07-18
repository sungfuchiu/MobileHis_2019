using Autofac;
using Autofac.Integration.Mvc;
using Common;
using MobileHis_2019.Repository;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Service;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019
{
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static void Register()
        {
            // 容器建立者
            ContainerBuilder builder = new ContainerBuilder();
            
            builder.RegisterType<MobileHis.Data.MobileHISEntities>().As<DbContext>().InstancePerRequest();
            //builder.Register(c =>
            //    {
            //        if (HttpContext.Current.User != null)
            //            return HttpContext.Current.User as CustomPrincipal;
            //        return new CustomPrincipal();
            //    }).As<CustomPrincipal>().InstancePerRequest();
            //builder.Register(c => HttpContext.Current.User).As<IPrincipal>().InstancePerRequest();
            builder.Register(c => new WrappedPrincipal(HttpContext.Current.User)).As<WrappedPrincipal>().InstancePerRequest();
            //builder.RegisterInstance(HttpContext.Current.User).As<CustomPrincipal>();
            //var user = HttpContext.Current.User as CustomPrincipal;
            //builder.Register(c => user).As<CustomPrincipal>().InstancePerRequest();
            //builder.Register(c => c.Resolve<IPrincipal>() as CustomPrincipal).As<CustomPrincipal>().InstancePerRequest();
            //builder.RegisterType(typeof(HttpContext.Current.User)).As<CustomPrincipal>().InstancePerRequest();
            builder.RegisterType(typeof(EFUnitOfWork)).As<IUnitOfWork>();
            builder.RegisterAssemblyTypes(typeof(Service.ServiceModule).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
            builder.Register<MobileHis.Models.Interface.GetCodeFileSelectList>(ctx => ctx.Resolve<ICodeFileService>().GetDropDownList ).As<MobileHis.Models.Interface.GetCodeFileSelectList>();
            builder.Register<MobileHis.Models.ViewModel.AccountCreateView.GetDepartmentList>(ctx => ctx.Resolve<IDepartmentService>().GetCheckBoxList).As<MobileHis.Models.ViewModel.AccountCreateView.GetDepartmentList>();
            builder.Register<MobileHis.Models.ViewModel.AccountCreateView.GetRoleList>(ctx => ctx.Resolve<IRoleService>().GetRoles).As<MobileHis.Models.ViewModel.AccountCreateView.GetRoleList>();
            builder.Register<MobileHis.Models.Areas.Sys.ViewModels.CodeFileViewModel.GetCategoryList>(ctx => ctx.Resolve<ICodeFileService>().GetCategoryList).As<MobileHis.Models.Areas.Sys.ViewModels.CodeFileViewModel.GetCategoryList>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // 建立容器
            IContainer container = builder.Build();

            // 解析容器內的型別
            //AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver(container);
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            // 建立相依解析器
            //GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            DependencyResolver.SetResolver(resolver);


            //// 第一步，建立ContainerBuilder
            //var builder = new ContainerBuilder();

            //// 開始 第二步，註冊service

            //// 註冊ConsoleLogger這個class為ILogger Service的Component
            //builder.RegisterType<DrugVendorBLL>().As<IDrugVendorBLL>();

            //// 如果寫法是：builder.RegisterType<ConsoleLogger>(); 
            //// 那麼就是ConsoleLogger這個class為ConsoleLogger Service的Component

            //// 註冊自己實例化出來的物件
            //// 上面是只註冊class type（因此，用到的時候是autofac幫你new出來），這邊是直接用這個object
            //var output = new StringWriter();
            //builder.RegisterInstance(output).As<TextWriter>();

            //// 用lambda 註冊會更有彈性，因為傳進來的c是container的instance，因此可以用c來做一些複雜的東西。
            //builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();

            //// 假設不想要一個一個註冊，可以用scan的方式。
            //// 下面scan一個assembly所有的type，當那個type的名字最後結尾是Repository的時候，
            //// 把它註冊的service設為這個class的interface
            //builder.RegisterAssemblyTypes(myAssembly)
            // .Where(t => t.Name.EndsWith("Repository"))
            // .AsImplementedInterfaces();

            ////結束 第二步

            //// 第三步，註冊都完成了，建立自己的container
            //var container = builder.Build();

            //// 第四部，從container取得對應的component。
            //// 這邊用using包起來，因為出了這個scope，一切Resolve出來的都會被釋放掉。
            //// 這部份在我們整個系列碰到並不多，因為不建議自己每一個這樣取出來，
            //// 而是用深度整合的方式來讓一切像自動發生。
            //// 詳細之後就會比較清楚
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var reader = container.Resolve<IConfigReader>();
            //}
        }
    }
}