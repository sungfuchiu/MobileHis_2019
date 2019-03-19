using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using MobileHis_2019;
using MobileHis.Models.Areas.Sys.ViewModels;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ICD10Controller : MobileHis_2019.Controllers.BaseController
    {
        private ICD10BLL icd10BLL;
        public ICD10Controller()
        {
            icd10BLL = new ICD10BLL();
        }
        [HttpGet]
        public ActionResult Index(int? page, string keyword = "", string type = "")
        {
            int currentPageIndex = (page ?? 1) - 1;
            ViewBag.keyword = keyword;
            ViewBag.type = type;
            IEnumerable<ICD10ViewModel> model = icd10BLL.GetList(keyword, type)
                            .ToPagedList(currentPageIndex + 1, GlobalVariable.PageSize);
            return View(model);
        }
        [HttpPost]
        public int Create(string code, string name, string type)
        {
            return icd10BLL.Add(code, name, type);
        }
        [HttpPost]
        public bool Edit(string code, string name, string type)
        {
            return icd10BLL.Edit(code, name, type);
        }
    }
}