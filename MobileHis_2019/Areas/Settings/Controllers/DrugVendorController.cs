using BLL;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class DrugVendorController : BaseAPIController<DrugVendorModel>
    {
        private DrugVendorBLL _drugVendorBLL;
        private DrugBLL _drugBLL;
        private ModelStateWrapper _modelState;
        public DrugVendorController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _drugVendorBLL = new DrugVendorBLL(_modelState);
            _drugBLL = new DrugBLL(_modelState);
            IBLL = _drugVendorBLL;
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult SearchDrugs()
        {
            string keyword = Request.QueryString.Get("kw");
            string type = Request.QueryString.Get("Ty");
            string ID = Request.QueryString.Get("id");
            Guid? guid = string.IsNullOrEmpty(ID) ? (Guid?)null : new Guid(ID); 
            var drugs = _drugBLL.Filter(keyword, keyword, guid, type).Select(x => new
            {
                id = x.GID,
                text = "[" + x.OrderCode + "] " + x.Title,
            }).Take(100);
            return Json(drugs, JsonRequestBehavior.AllowGet);
        }
    }
}