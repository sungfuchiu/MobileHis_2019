using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Controllers
{
    public class LogOnController : Controller
    {
        // GET: Logon
        public ActionResult Index()
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1)); //設為過期
            Response.Cache.SetCacheability(HttpCacheability.NoCache); //設定Cache-Control的HTTP標頭，Header的Cache-Control, Pragma, Expires一次設足，就可以確保網頁內容不被Cache住了。

            return View();
        }
    }
}