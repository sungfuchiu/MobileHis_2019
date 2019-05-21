using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Common;
using MobileHis.Models.Areas.Sys.ViewModels;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class CategoryController : MobileHis_2019.Controllers.BaseController
    {
        private CodeFileBLL _codeFileBLL;
        private SettingBLL _settingBLL;
        private ModelStateWrapper _modelState;
        public CategoryController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _codeFileBLL = new CodeFileBLL(_modelState);
            _settingBLL = new SettingBLL(_modelState);
        }
        // GET: Settings/Category
        [HttpGet]
        public ActionResult Index(/*string itemType, string keyword, int? page*/CategoryModel model)
        {
            //CategoryModel model = new CategoryModel(_codeFileBLL.GetDropDownList);
            model.SelectListEvent += _settingBLL.GetDropDownList;
            //model.ItemTypeSelected = itemType;
            //model.Keyword = keyword;
            model.CategoryPageList = _codeFileBLL
                                    .GetList(model.ItemType, model.Keyword)
                                    .ToPagedList(model.Page, Config.PageSize);
            return View(model);
        }
    }
}