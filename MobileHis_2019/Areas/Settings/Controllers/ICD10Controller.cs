﻿using BLL;
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

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class ICD10Controller : MobileHis_2019.Controllers.BaseController
    {
        //private ICD10BLL icd10BLL;
        //private ModelStateWrapper modelState;
        IICD10Service _ICD10Service;
        public ICD10Controller(IICD10Service ICD10Service)
        {
            //modelState = new ModelStateWrapper(ModelState);
            //icd10BLL = new ICD10BLL(modelState);
            ICD10Service.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _ICD10Service = ICD10Service;
        }
        [HttpGet]
        public ActionResult Index(int? page, string keyword = "", string type = "")
        {
            int currentPageIndex = (page ?? 1) - 1;
            ViewBag.keyword = keyword;
            ViewBag.type = type;
            IEnumerable<ICD10ViewModel> model = _ICD10Service.GetList(keyword, type)
                            .ToPagedList(currentPageIndex + 1, GlobalVariable.PageSize);
            ViewBag._Update = true;
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