using BLL;
using MobileHis.Models.Areas.Sys.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class DepartmentController : MobileHis_2019.Controllers.APIBaseController<DepartmentIndexModel>
    {
        private DepartmentBLL _deparmentBLL;
        private ModelStateWrapper _modelState;
        public DepartmentController()
        {
            _modelState = new ModelStateWrapper(ModelState);
            _deparmentBLL = new DepartmentBLL(_modelState);
            IBLL = _deparmentBLL;
        }
        [HttpPost]
        public string GetOneByJson(int id)
        {
            return JsonConvert.SerializeObject(_deparmentBLL.Read(a => a.ID == id));
        }
    }
}