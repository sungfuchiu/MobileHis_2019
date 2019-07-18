using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileHis_2019.Controllers;
using MobileHis_2019.Service.Service;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class RoleController : BaseController
    {
        private IRoleService _roleService;
        private IAppToRoleService _appToRoleService;
        public RoleController(
            IRoleService roleService, 
            ISystemLogService systemLogService,
            IAppToRoleService appToRoleService) : base(systemLogService)
        {
            _roleService = roleService;
            _appToRoleService = appToRoleService;
        }
        // GET: Settings/Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string roleName)
        {
            _roleService.Create(roleName);
            Response.Write("Y");
            return null;
        }
        public ActionResult Delete(int? roleId)
        {
            if (roleId != null)
                _roleService.Delete(roleId.Value);
            Response.Write("Y");
            return null;
        }
        [HttpPost]
        public ActionResult GetList()
        {
            return Json(_roleService.GetList());
        }
        [HttpPost]
        public ActionResult genTable(int id)
        {
            return Content(_appToRoleService.GenerateTable(id));
        }
        [HttpPost]
        public ActionResult setTable(int id, string key, bool isSet)
        {
            _appToRoleService.SetTable(id, key, isSet);
            Response.Write("Y");
            return null;
        }
    }
}