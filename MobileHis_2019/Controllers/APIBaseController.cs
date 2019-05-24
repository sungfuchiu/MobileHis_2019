using BLL.Interface;
using MobileHis.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class APIBaseController<TModel> : BaseController
    {
        protected IAPIBLL<TModel> IBLL;
        // GET: Settings/Category
        [HttpGet]
        public ActionResult Index(/*string itemType, string keyword, int? page*//*CodeFileViewModel model*/TModel model)
        {
            //CategoryModel model = new CategoryModel(_codeFileBLL.GetDropDownList);
            //model.ItemTypeSelected = itemType;
            //model.Keyword = keyword;
            //model.SelectListEvent += _settingBLL.GetDropDownList;
            //model.CategoryPageList = _codeFileBLL
            //                        .GetList(model.ItemType, model.Keyword)
            //                        .ToPagedList(model.Page, Config.PageSize);
            IBLL.Index(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TModel model/*int? parentId, string itemType, string itemCode, string itemDesc, string itemRemark*/)
        {
            if (ModelState.IsValid)
            {
                IBLL.Create(model);
            }
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Update(TModel model/*string ID, int? parentId, string itemDesc, string itemRemark*/)
        {
            ModelState.Clear();
            IBLL.Update(model);
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
            IBLL.Delete(ID);
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}