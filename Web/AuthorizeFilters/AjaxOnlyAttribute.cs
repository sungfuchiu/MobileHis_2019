using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext filterContext, System.Reflection.MethodInfo methodInfo)
        {
            return filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}