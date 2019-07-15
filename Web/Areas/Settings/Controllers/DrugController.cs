using Common;
using MobileHis_2019.Service.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class DrugController : MobileHis_2019.Controllers.BaseController
    {
        IDrugSettingService _drugSettingService;
        public DrugController(IDrugSettingService drugSettingService, ISystemLogService systemLogService) : base(systemLogService)
        {
            drugSettingService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
            _drugSettingService = drugSettingService;
        }
        // GET: Settings/Drug
        [HttpGet]
        public ActionResult FrequencyPairs()
        {
            return Json(
                JsonConvert.SerializeObject(_drugSettingService.FrequencyPairs())
                ,JsonRequestBehavior.AllowGet);
        }
    }
}