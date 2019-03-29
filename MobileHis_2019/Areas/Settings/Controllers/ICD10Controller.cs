using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using MobileHis_2019;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis.Models.ViewModels;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ICD10Controller : MobileHis_2019.Controllers.BaseController
    {
        private ICD10BLL icd10BLL;
        private ModelStateWrapper modelState;
        public ICD10Controller()
        {
            modelState = new ModelStateWrapper(ModelState);
            icd10BLL = new ICD10BLL(modelState);
        }
        [HttpGet]
        public ActionResult Index(int? page, string keyword = "", string type = "")
        {
            int currentPageIndex = (page ?? 1) - 1;
            ViewBag.keyword = keyword;
            ViewBag.type = type;
            IEnumerable<ICD10ViewModel> model = icd10BLL.GetList(keyword, type)
                            .ToPagedList(currentPageIndex + 1, GlobalVariable.PageSize);
            ViewBag._Update = true;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(string code, string name, string type)
        {
            
            return Json(new JsonBoolResultModel()
            {
                isSuccess = icd10BLL.Add(code, name, type),
                errorMessage = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
        [HttpPost]
        public ActionResult Edit(string code, string name, string type)
        {
            return Json(new JsonBoolResultModel()
            {
                isSuccess = icd10BLL.Edit(code, name, type),
                errorMessage = ModelState[""]?.Errors[0].ErrorMessage
            });
        }
    }
}