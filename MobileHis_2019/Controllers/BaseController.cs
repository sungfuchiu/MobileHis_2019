using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Common;
using MobileHis.Models.ApiModel;
using BLL;

namespace MobileHis_2019.Controllers
{
    public class BaseController : Controller
    {
        public class ModelStateWrapper : IValidationDictionary
        {
            public ModelStateWrapper(ModelStateDictionary modelStateDictionary)
            {
                modelState = modelStateDictionary;
            }
            private ModelStateDictionary modelState { get; set; }
            public void AddGeneralError(string errorMessage)
            {
                modelState.AddModelError(string.Empty, errorMessage);
            }
            public void AddPropertyError<TModel>(
                Expression<Func<TModel, object>> expression, 
                string errorMessage)
            {
                if (expression == null)
                {
                    throw new ArgumentNullException("method");
                }
                modelState.AddModelError(ExpressionHelper.GetExpressionText(expression), errorMessage);
            }

            public bool Any()
            {
                return modelState.Any();
            }

            public bool IsValid()
            {
                return modelState.IsValid;
            }
        }
        protected ActionResult ImageNotFound()
        {
            return File(Server.MapPath("~/Image/no_image_found.jpg"), "image/jpg");
        }

        protected void EditSuccessfully()
        {
            ViewBag.Message = "Setting Successfully";
            ViewBag.Redirect = Url.Action("Index");
        }

    }
}