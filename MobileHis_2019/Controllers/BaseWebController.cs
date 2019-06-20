using BLL.Interface;
using MobileHis_2019.Service.Interface;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class BaseWebController<TModel> : BaseController 
    {
        //protected IWebBLL<TModel> IBLL;
        protected IWebService<TModel> IService;
        protected TModel Model;
        public BaseWebController(ISystemLogService systemLogService) : base(systemLogService) { }
        // GET: Settings/Category
        [HttpGet]
        public ActionResult Index(TModel model)
        {
            IService.Index(model);
            return View(model);
        }

        public ActionResult Create()
        {
            return View("Edit", Model);
        }
        [HttpPost]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                IService.Create(model);
                if (ModelState.IsValid)
                    EditSuccessfully();
            }
            return View("Edit", model);
        }
        public ActionResult Update(int ID)
        {
            Model = IService.Read(ID);
            return View("Edit", Model);
        }
        [HttpPost]
        public ActionResult Update(TModel model/*string ID, int? parentId, string itemDesc, string itemRemark*/)
        {
            if (ModelState.IsValid)
            {
                IService.Update(model);
                if (ModelState.IsValid)
                    EditSuccessfully();
            }
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            IService.Delete(ID);
            return View();
        }
    }
}