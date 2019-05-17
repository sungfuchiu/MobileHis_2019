using BLL;
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
        private DrugSettingBLL _drugSettingBLL;
        private ModelStateWrapper _modelStata;
        public DrugController()
        {
            _modelStata = new ModelStateWrapper(ModelState);
            _drugSettingBLL = new DrugSettingBLL(_modelStata);
        }
        // GET: Settings/Drug
        [HttpGet]
        public ActionResult FrequencyPairs()
        {
            return Json(
                JsonConvert.SerializeObject(_drugSettingBLL.FrequencyPairs())
                ,JsonRequestBehavior.AllowGet);
        }
    }
}