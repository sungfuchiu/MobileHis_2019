using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using MobileHis_2019;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis.Models.ViewModels;
using MobileHis_2019.Service.Service;
using Common;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ICD10Controller : MobileHis_2019.Controllers.BaseController
    {
        IICD10Service _ICD10Service;
        public ICD10Controller(IICD10Service ICD10Service, ISystemLogService systemLogService) : base(systemLogService)
        {
            ICD10Service.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _ICD10Service = ICD10Service;
        }
        [HttpGet]
        public ActionResult Index(ICD10ViewModel model)
        {
            model.ICD10PageList = _ICD10Service.GetList(model.Keyword, model.Type)
                                .ToPagedList(model.Page, Config.PageSize);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(string code, string name, string type)
        {
            
            return Json(new JsonBoolResultModel()
            {
                isSuccess = _ICD10Service.Add(code, name, type),
                errorMessage = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Edit(string code, string name, string type)
        {
            return Json(new JsonBoolResultModel()
            {
                isSuccess = _ICD10Service.Edit(code, name, type),
                errorMessage = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}