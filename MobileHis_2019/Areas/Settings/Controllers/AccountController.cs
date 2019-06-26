using Common;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class AccountController : MobileHis_2019.Controllers.BaseController
    {
        IAccountService _accountService;
        public AccountController(ISystemLogService systemLogService, IAccountService accountService) : base(systemLogService)
        {
            _accountService = accountService;
        }
        // GET: Settings/User
        public ActionResult Index(AccountIndexView model)
        {
            model.Accounts = _accountService.GetList(model.Keyword).ToPagedList(model.Page, Config.PageSize);
            return View(model);
        }
    }
}