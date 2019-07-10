using MobileHis.Models.ApiModel;
using MobileHis_2019.Service.Interface;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class BaseAPIController<TModel> : BaseController
    {
        //protected IAPIBLL<TModel> IBLL;
        protected IAPIService<TModel> IService;
        // GET: Settings/Category
        public BaseAPIController(ISystemLogService systemLogService) : base(systemLogService) { }
        [HttpGet]
        public virtual ActionResult Index(TModel model)
        {
            IService.Index(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                IService.Create(model);
            }
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Update(TModel model)
        {
            ModelState.Clear();
            IService.Update(model);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ModelState.Clear();
            IService.Delete(ID);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}