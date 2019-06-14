using BLL;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class VendorController : MobileHis_2019.Controllers.BaseWebController<VendorModel>
    {
        //private VendorBLL _vendorBLL;
        //private CodeFileBLL _codeFileBLL;
        //private ModelStateWrapper _modelState;
        ICodeFileService _codeFileService;
        IDrugVendorService _drugVendorService;
        public VendorController(ICodeFileService codeFileService, IDrugVendorService drugVendorService)
        {
            //_modelState = new ModelStateWrapper(ModelState);
            //_vendorBLL = new VendorBLL(_modelState);
            //_codeFileBLL = new CodeFileBLL(_modelState);
            //IBLL = _vendorBLL;
            codeFileService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            drugVendorService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            _codeFileService = codeFileService;
            _drugVendorService = drugVendorService;
            Model = new VendorModel(codeFileService.GetDropDownList);
        }
    }
}