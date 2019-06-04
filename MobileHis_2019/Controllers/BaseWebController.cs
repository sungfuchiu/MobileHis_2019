using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class BaseWebController<TModel> : BaseController where TModel : new()
    {
        protected IWebBLL<TModel> IBLL;
        // GET: Settings/Category
        [HttpGet]
        public ActionResult Index(TModel model)
        {
            IBLL.Index(model);
            return View(model);
        }

        public ActionResult Create()
        {
            return View("Edit",new TModel());
        }
        [HttpPost]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.Create(model);
            }
            return View("Edit", model);
        }
        public ActionResult Update(int ID)
        {
            TModel model = IBLL.Read(ID);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Update(TModel model/*string ID, int? parentId, string itemDesc, string itemRemark*/)
        {
            if (ModelState.IsValid)
            {
                IBLL.Update(model);
            }
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            IBLL.Delete(ID);
            return View();
        }
    }
}