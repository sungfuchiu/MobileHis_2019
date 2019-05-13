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
        private DrugBLL drugBLL;
        private ModelStateWrapper _modelStata;
        public DrugController()
        {
            _modelStata = new ModelStateWrapper(ModelState);
            drugBLL = new DrugBLL(_modelStata);
        }
        // GET: Settings/Drug
        [HttpGet]
        public ActionResult FrequencyPairs()
        {
            return Json(
                JsonConvert.SerializeObject(drugBLL.FrequencyPairs())
                ,JsonRequestBehavior.AllowGet);
        }
    }
}