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
    public class BaseController<TModel> : Controller
    {
        IBLL<TModel> BLL;
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

        // GET: Settings/Category
        [HttpGet]
        public ActionResult Index(/*string itemType, string keyword, int? page*//*CodeFileViewModel model*/TModel model)
        {
            //CategoryModel model = new CategoryModel(_codeFileBLL.GetDropDownList);
            //model.ItemTypeSelected = itemType;
            //model.Keyword = keyword;
            model.SelectListEvent += _settingBLL.GetDropDownList;
            model.CategoryPageList = _codeFileBLL
                                    .GetList(model.ItemType, model.Keyword)
                                    .ToPagedList(model.Page, Config.PageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TModel model/*int? parentId, string itemType, string itemCode, string itemDesc, string itemRemark*/)
        {
            if (ModelState.IsValid)
            {
                BLL.Create(model);
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
            if (ModelState.IsValid)
            {
                BLL.Update(model);
            }
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult ApiDel(int ID)
        {
            if (ModelState.IsValid)
            {
                BLL.Delete(ID);
            }
            return Json(new BaseApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}