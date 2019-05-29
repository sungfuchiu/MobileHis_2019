using BLL;
using Common;
using MobileHis.Models.Areas.Sys.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class EducationController : MobileHis_2019.Controllers.APIBaseController<EducationModel>
    {
        private EducationBLL _educationBLL;
        private ModelStateWrapper _modelState;
        EducationController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _educationBLL = new EducationBLL(_modelState);
            IBLL = _educationBLL;
        }
        // GET: Settings/Education
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public string GetGuardianList(int typeID)
        {
            return JsonConvert.SerializeObject(_educationBLL.GetEducationList(typeID));
        }
    }
}