using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MobileHis.Models.ViewModel;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class SettingController : Controller
    {
        // GET: Settings/Setting
        public ActionResult Index()
        {
            SettingBLL bll = new SettingBLL();

            SettingView settingView = bll.GetAllSetting();
            return View(settingView);
        }

        public ActionResult DefaultSetting(SettingView setting)
        {
            SettingBLL bll = new SettingBLL();
            //setting.SystemSettingView.PartnerFile = Request.Files;
            bll.SetGeneralSetting(setting.SystemSettingView);
            return Redirect("Index");
        }
        public ActionResult InfoSetting(SettingView setting)
        {
            SettingBLL bll = new SettingBLL();
            bll.SetInfoSetting(setting.InfoSettingView);
            return Redirect("Index");
        }
        public ActionResult OtherSetting(SettingView setting)
        {
            SettingBLL bll = new SettingBLL();
            bll.SetOthersSetting(setting.OthersSettingView);
            return Redirect("Index");
        }
        public ActionResult MailSetting(SettingView setting)
        {
            SettingBLL bll = new SettingBLL();
            bll.SetMailSetting(setting.MailSettingView);
            return Redirect("Index");
        }
        [HttpPost]
        public bool DeleteImage(string cat, string settingName, string fileName)
        {
            SettingBLL bll = new SettingBLL();
            return bll.DeleteImage(cat, settingName, fileName);
        }
    }
}