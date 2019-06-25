using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Filters
{
    //可以在action的地方綁定身分，不過感覺沒甚麼用，因為我用autoFac已經實現注入所有IPrincipal的功能
    public class IPrincipalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if(controllerContext == null)
            {
                throw new ArgumentException("controllerContext");
            }
            if(bindingContext == null)
            {
                throw new ArgumentException("bindingContext");
            }
            IPrincipal user = controllerContext.HttpContext.User;
            return user;
        }
    }
}