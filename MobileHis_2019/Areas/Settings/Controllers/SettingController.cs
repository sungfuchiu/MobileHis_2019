using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MobileHis.Models.ViewModel;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class SettingController : MobileHis_2019.Controllers.BaseController
    {
        private SettingBLL settingBLL;
        private ModelStateWrapper modelState;
        public SettingController()
        {
            modelState = new ModelStateWrapper(ModelState);
            settingBLL = new SettingBLL(modelState);
        }
        // GET: Settings/Setting
        public ActionResult Index()
        {
            if (TempData["ModelState"] != null)
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            SettingView settingView = settingBLL.GetAllSetting();
            return View(settingView);
        }

        public ActionResult DefaultSetting(SettingView setting)
        {
            settingBLL.SetGeneralSetting(setting.SystemSettingView);
            if(!ModelState.IsValid)
                TempData["ModelState"] = ModelState;
            return RedirectToAction("Index");
        }
        public ActionResult InfoSetting(SettingView setting)
        {
            settingBLL.SetInfoSetting(setting.InfoSettingView);
            return Redirect("Index");
        }
        public ActionResult OtherSetting(SettingView setting)
        {
            settingBLL.SetOthersSetting(setting.OthersSettingView);
            return Redirect("Index");
        }
        public ActionResult MailSetting(SettingView setting)
        {
            settingBLL.SetMailSetting(setting.MailSettingView);
            return Redirect("Index");
        }
        [HttpPost]
        public bool DeleteImage(string cat, string settingName, string fileName)
        {
            return settingBLL.DeleteImage(cat, settingName, fileName);
        }
    }
}