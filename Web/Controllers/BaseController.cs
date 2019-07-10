using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Common;
using MobileHis.Models.ApiModel;
using MobileHis.Data;
using System.Diagnostics;
using MobileHis.Models.Object;
using MobileHis_2019.Service.Service;

namespace MobileHis_2019.Controllers
{
    public class BaseController : Controller
    {
        ISystemLogService _systemLogService;
        public BaseController(ISystemLogService systemLogService)
        {
            _systemLogService = systemLogService;
        }
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
        protected virtual new CustomPrincipal User
        {
            get => HttpContext.User as CustomPrincipal;
        }

        public virtual void Log(string Message, FunctionType Type = FunctionType.NoRecord, string user = "")
        {
            StackFrame frame = new StackFrame(1, true);
            var method = frame.GetMethod();

            SystemLog record = new SystemLog();
            record.Message = Message;
            record.Controller = method.ReflectedType.Name;
            record.Action = method.Name;
            record.FunctionType = Enum.GetName(typeof(FunctionType), Type);

            //record.User = string.IsNullOrEmpty(user) ? User.Name : user;
            record.UserIPAddress = Request.ServerVariables["REMOTE_ADDR"]; ;
            //record.CreateAt = DateTime.Now;
            _systemLogService.Log(record);
        }

    }
}