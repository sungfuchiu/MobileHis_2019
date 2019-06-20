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
        IVendorService _vendorService;
        public VendorController(ICodeFileService codeFileService, IVendorService vendorService, ISystemLogService systemLogService) : base(systemLogService)
        {
            //_modelState = new ModelStateWrapper(ModelState);
            //_vendorBLL = new VendorBLL(_modelState);
            //_codeFileBLL = new CodeFileBLL(_modelState);
            //IBLL = _vendorBLL;
            codeFileService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            vendorService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            _codeFileService = codeFileService;
            _vendorService = vendorService;
            IService = vendorService;
            Model = new VendorModel(codeFileService.GetDropDownList);
        }
    }
}