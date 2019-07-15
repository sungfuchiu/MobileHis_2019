using Common;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Controllers;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class DrugVendorController : BaseAPIController<DrugVendorModel>
    {
        IDrugService _drugService;
        public DrugVendorController(
            IDrugVendorService drugVendorService, 
            IDrugService drugService,
            ISystemLogService systemLogService) : base(systemLogService)
        {
            drugVendorService.InitialiseIValidationDictionary
               (new ModelStateWrapper(this.ModelState));
            IService = drugVendorService;
            _drugService = drugService;
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult SearchDrugs()
        {
            string keyword = Request.QueryString.Get("kw");
            string type = Request.QueryString.Get("Ty");
            string ID = Request.QueryString.Get("id");
            Guid? guid = string.IsNullOrEmpty(ID) ? (Guid?)null : new Guid(ID); 
            var drugs = _drugService.Filter(keyword, keyword, guid, type).Select(x => new
            {
                id = x.GID,
                text = "[" + x.OrderCode + "] " + x.Title,
            }).Take(100);
            return Json(drugs, JsonRequestBehavior.AllowGet);
        }
    }
}