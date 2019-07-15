using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Service.Service;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class SettingController : MobileHis_2019.Controllers.BaseController
    {
        ISettingService _settingService;
        public SettingController(ISettingService settingService, ISystemLogService systemLogService) : base(systemLogService)
        {
            settingService.InitialiseIValidationDictionary(
                new ModelStateWrapper(ModelState));
            _settingService = settingService;
        }
        // GET: Settings/Setting
        public ActionResult Index()
        {
            if (TempData["ModelState"] != null)
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            SettingView settingView = _settingService.GetAllSetting();
            return View(settingView);
        }

        public ActionResult DefaultSetting(SettingView setting)
        {
            if(!_settingService.SetGeneralSetting(setting))
                TempData["ModelState"] = ModelState;
            return RedirectToAction("Index");
        }
        public ActionResult InfoSetting(SettingView setting)
        {
            if(_settingService.SetInfoSetting(setting))
                TempData["ModelState"] = ModelState;
            return Redirect("Index");
        }
        public ActionResult OtherSetting(SettingView setting)
        {
            if(_settingService.SetOthersSetting(setting))
                TempData["ModelState"] = ModelState;
            return Redirect("Index");
        }
        public ActionResult MailSetting(SettingView setting)
        {
            if(_settingService.SetMailSetting(setting))
                TempData["ModelState"] = ModelState;    
            return Redirect("Index");
        }
        [HttpPost]
        public bool DeleteImage(string cat, string settingName, string fileName)
        {
            return _settingService.DeleteImage(cat, settingName, fileName);
        }
    }
}