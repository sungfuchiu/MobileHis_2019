using Common;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Service.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class DepartmentController : MobileHis_2019.Controllers.BaseAPIController<DepartmentIndexModel>
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService, ISystemLogService systemLogService) : base(systemLogService)
        {
            departmentService.InitialiseIValidationDictionary
               (new ModelStateWrapper(this.ModelState));
            IService = departmentService;
            _departmentService = departmentService;
        }
        [HttpPost]
        public string GetOneByJson(int id)
        {
            return JsonConvert.SerializeObject(_departmentService.Read(a => a.ID == id));
        }
    }
}