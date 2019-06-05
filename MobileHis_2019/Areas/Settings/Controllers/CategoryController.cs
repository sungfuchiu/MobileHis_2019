using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Common;
using MobileHis.Models.ApiModel;
using MobileHis.Models.Areas.Sys.ViewModels;
using Newtonsoft.Json;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class CategoryController : MobileHis_2019.Controllers.BaseAPIController<CodeFileViewModel>
    {
        private CodeFileBLL _codeFileBLL;
        private ModelStateWrapper _modelState;
        public CategoryController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _codeFileBLL = new CodeFileBLL(_modelState);
            IBLL = _codeFileBLL;
        }
        //// GET: Settings/Category
        //[HttpGet]
        //public ActionResult Index(/*string itemType, string keyword, int? page*/CodeFileViewModel model)
        //{
        //    //CategoryModel model = new CategoryModel(_codeFileBLL.GetDropDownList);
        //    //model.ItemTypeSelected = itemType;
        //    //model.Keyword = keyword;
        //    model.SelectListEvent += _settingBLL.GetDropDownList;
        //    model.CategoryPageList = _codeFileBLL
        //                            .GetList(model.ItemType, model.Keyword)
        //                            .ToPagedList(model.Page, Config.PageSize);
        //    return View(model);
        //}

        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Create(CodeFileViewModel model/*int? parentId, string itemType, string itemCode, string itemDesc, string itemRemark*/)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _codeFileBLL.Create(model);
        //    }
        //    return Json(new BaseApiModel()
        //    {
        //        success = ModelState.IsValid,
        //        message = ModelState[""]?.Errors[0].ErrorMessage
        //    });
        //    //using (CodeFileDal dal = new CodeFileDal())
        //    //{
        //    //    switch (dal.Create(parentId, itemType, itemCode, itemDesc, itemRemark, User))
        //    //    {
        //    //        case Enums.DbStatus.OK: Response.Write("Y"); break;
        //    //        case Enums.DbStatus.Duplicate: Response.Write("D"); break;
        //    //        case Enums.DbStatus.Error: Response.Write(""); break;
        //    //    }

        //    //}

        //    //return null;
        //}

        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Update(CodeFileViewModel model/*string ID, int? parentId, string itemDesc, string itemRemark*/)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _codeFileBLL.Update(model);
        //    }
        //    return Json(new BaseApiModel()
        //    {
        //        success = ModelState.IsValid,
        //        message = ModelState[""]?.Errors[0].ErrorMessage
        //    });
        //    //using (CodeFileDal dal = new CodeFileDal())
        //    //{
        //    //    switch (dal.Update(ID, parentId, itemDesc, itemRemark, User))
        //    //    {
        //    //        case Enums.DbStatus.OK: Response.Write("Y"); break;
        //    //        case Enums.DbStatus.Error: Response.Write(""); break;
        //    //    }

        //    //}

        //    //return null;
        //}

        ///// <summary>
        ///// 刪除
        ///// </summary>     
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Del(int ID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _codeFileBLL.Delete(ID);
        //    }
        //    return Json(new BaseApiModel()
        //    {
        //        success = ModelState.IsValid,
        //        message = ModelState[""]?.Errors[0].ErrorMessage
        //    });
        //    //using (CodeFileDal dal = new CodeFileDal())
        //    //{
        //    //    switch (dal.Del(ID))
        //    //    {
        //    //        case Enums.DbStatus.OK:
        //    //            Response.Write("Y"); break;
        //    //        case Enums.DbStatus.Error:
        //    //            Response.Write(""); break;
        //    //    }
        //    //}

        //    //return null;
        //}
        [HttpGet]
        public string GetListByItemType(string typeCode)
        {
            return JsonConvert.SerializeObject(_codeFileBLL.GetDropDownList(typeCode));
        }
    }
}