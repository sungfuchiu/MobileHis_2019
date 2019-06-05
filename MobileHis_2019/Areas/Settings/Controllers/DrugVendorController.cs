using BLL;
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
        private ModelStateWrapper _modelState;
        public DrugVendorController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _drugVendorBLL = new DrugVendorBLL(_modelState);
            IBLL = _drugVendorBLL;
        }
    }
}