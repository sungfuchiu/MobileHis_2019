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
            SettingView view = bll.GetAllSetting();
            return View(bll.GetAllSetting());
        }
    }
}