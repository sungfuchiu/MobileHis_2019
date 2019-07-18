using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Filters
{
    [Flags]
    public enum AuthType
    {
        Add = 1,
        Delete = 2,
        Update = 4,
        Read = 8,
        Print = 16
    }
    public class AuthInfo
    {
        public List<AuthParents> Parents { get; set; }
    }
    public class AuthParents
    {
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentArea { get; set; }
        public string ResourceKey { get; set; }
        public string IconClass { get; set; }
        public List<AuthItems> Items { get; set; }
    }
    public class AuthItems
    {
        public string Area { get; set; }
        public string Control { get; set; }
        public string Action { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ResourceKey { get; set; }
        public bool HasAdd { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasDelete { get; set; }
        public bool HasPrint { get; set; }
    }
    public class AuthenticateFilter : ActionFilterAttribute
    {
        string _actionName;
        AuthType _authType;
        AuthInfo _authInfo;
        IPrincipal _principal;
        //AuthItems _authPage;
        public AuthenticateFilter(AuthType authType, IPrincipal principle, string actionName="")
        {
            _actionName = actionName;
            _authType = authType;
            _principal = principle;

        }
        public AuthInfo AuthInfo {
            get
            {
                if(_authInfo != null)
                {
                    string userAuth = HttpContext.Current.Session["userAuth"].ToString();
                    _authInfo = JsonConvert.DeserializeObject<AuthInfo>(userAuth);
                }
                return _authInfo;
            }
        }
        private AuthType _print = AuthType.Print;
        private AuthType _add = AuthType.Add;
        private AuthType _delete = AuthType.Delete;
        private AuthType _read = AuthType.Read;
        private AuthType _update = AuthType.Update;
        private string areaName;
        private string controllerName;
        private string actionName;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                bool byPass = false;
                if(AuthInfo == null)
                {
                    RedirectToLoginPage(filterContext);
                }
                else
                {
                    _principal = filterContext.HttpContext.User;
                    areaName = filterContext.RouteData.DataTokens["area"].ToString();
                    controllerName = filterContext.RouteData.Values["controller"].ToString();
                    actionName = (_actionName.IsNullOrEmpty()) ? filterContext.RouteData.GetRequiredString("action").ToString() : _actionName;

                    if(AuthInfo.Parents != null)
                    {
                        var authPage = AuthInfo.Parents.SelectMany(x => x.Items.Where(HasRoute).Select(y => y)).FirstOrDefault();
                        if (authPage != null)
                        {
                            filterContext.Controller.ViewBag.HasAdd = authPage.HasAdd;
                            filterContext.Controller.ViewBag.HasDelete = authPage.HasDelete;
                            filterContext.Controller.ViewBag.HasUpdate = authPage.HasUpdate;
                            filterContext.Controller.ViewBag.HasPrint = authPage.HasPrint;
                        }
                        if (PageCan(_add))
                        {
                            byPass = AuthInfo.Parents.Any(a => a.Items
                                        .Any(b => HasRoute(b) && b.HasAdd)) || byPass;
                        }
                        if (PageCan(_delete))
                        {
                            byPass = AuthInfo.Parents.Any(a => a.Items
                                        .Any(b => HasRoute(b) && b.HasDelete)) || byPass;
                        }
                        if (PageCan(_update))
                        {
                            byPass = AuthInfo.Parents.Any(a => a.Items
                                        .Any(b => HasRoute(b) && b.HasUpdate)) || byPass;
                        }
                        if (PageCan(_print))
                        {
                            byPass = AuthInfo.Parents.Any(a => a.Items
                                        .Any(b => HasRoute(b) && b.HasPrint)) || byPass;
                        }
                        if (PageCan(_read))
                        {
                            byPass = AuthInfo.Parents.Any(a => a.Items.Any(HasRoute)) || byPass;
                        }
                        if (!byPass)
                        {
                            RedirectToLoginPage(filterContext);
                        }
                    }
                }
            }catch(Exception ex)
            {
                RedirectToLoginPage(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }
        private bool HasRoute(AuthItems authItem)
        {
            return authItem.Area.Equals(areaName, StringComparison.InvariantCultureIgnoreCase) &&
                   authItem.Control.Equals(controllerName, StringComparison.InvariantCultureIgnoreCase) &&
                   authItem.Action.Equals(actionName, StringComparison.InvariantCultureIgnoreCase);
        }
        private bool PageCan(AuthType authType)
        {
            return (_authType & authType) == _authType;
        }
        private void RedirectToLoginPage(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new EmptyResult();
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.HttpContext.Response.End();
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(401, "Unauthorized");
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}