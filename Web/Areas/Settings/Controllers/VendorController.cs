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
        IVendorService _vendorService;
        public VendorController(IVendorService vendorService, ISystemLogService systemLogService) : base(systemLogService)
        {
            vendorService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            _vendorService = vendorService;
            IService = vendorService;
            Model = new VendorModel();
        }
    }
}