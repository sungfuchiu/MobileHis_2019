using BLL;
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
        //private DrugSettingBLL _drugSettingBLL;
        //private ModelStateWrapper _modelStata;
        IDrugSettingService _drugSettingService;
        public DrugController(IDrugSettingService drugSettingService)
        {
            //_modelStata = new ModelStateWrapper(ModelState);
            //_drugSettingBLL = new DrugSettingBLL(_modelStata);
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