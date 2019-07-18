using Common;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.Object;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Service.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MobileHis_2019.Controllers
{
    public class LogOnController : BaseController
    {
        private readonly ISettingService _settingService;
        private readonly IAccountService _accountService;
        public LogOnController(ISettingService settingService, IAccountService accountService, ISystemLogService systemLogService) : base(systemLogService)
        {
            _settingService = settingService;
            _accountService = accountService;

        }
        // GET: Logon
        public ActionResult Index(LogOnView model)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1)); //設為過期
            Response.Cache.SetCacheability(HttpCacheability.NoCache); //設定Cache-Control的HTTP標頭，Header的Cache-Control, Pragma, Expires一次設足，就可以確保網頁內容不被Cache住了,用來確保網頁是最新的狀態而不是完全不用cache
            Response.Cache.SetNoStore();
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            var path = _settingService.GetSetting("BK_img", MobileHis.Data.SettingTypes.Info)?.Value;
            if (!path.IsNullOrEmpty())
            {
                if (Storage.GetStorage(StorageScope.backgroundImg).FileExist(path))
                {
                    //ViewBag.BackgroundImage = path;
                    model.BackgroundIMG = path;
                }
            }
            //ViewBag.HospitalName = _settingService.GetSetting("Hospital_Name", MobileHis.Data.SettingTypes.Info).Value;
            model.HospitalName = _settingService.GetSetting("Hospital_Name", MobileHis.Data.SettingTypes.Info).Value;
            //ViewBag.PartnerPathList = _settingService.GetPartnerImagePath();
            model.PartnerPathList = _settingService.GetPartnerImagePath();
            return View();
        }
        [HttpPost]
        public ActionResult Index(LogOnView model, string ReturnUrl)
        {
            //using (SettingDal setting = new SettingDal())
            //{
            //    var path = setting.GetSetting("BK_img", SettingType.Default).Value;
            //    if (!string.IsNullOrEmpty(path))
            //    {
            //        var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);
            //        if (s.FileExist(path))
            //        {
            //            ViewBag.BK_img = path;//s.Open(category, path);
            //        }
            //    }
            //    var hospitalName = setting.GetSetting("Hospital_Name", SettingType.info).Value;
            //    ViewBag.hospitalName = hospitalName;
            //    var partnerPathList = setting.GetPartnerImagePath();
            //    ViewBag.partnerPathList = partnerPathList;
            //}
            //if (!ModelState.IsValid)
            //{
            //    //ViewBag.Message = string.Join(",", ModelState.Values
            //    //                        .SelectMany(x => x.Errors)
            //    //                        .Select(x => x.ErrorMessage));

            //}
            if(ModelState.IsValid)
            {
                
                    var account = _accountService.LogOn(model.Email + Config.AppSetting("EmailDomain"), model.Password);
                    if (account == null)
                        ViewBag.Message = "Login Failed";
                    else
                    {
                        //CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();

                        //serializeModel.ID = account.ID;
                        //serializeModel.Name = account.Name;
                        //serializeModel.Email = account.Email;
                        //serializeModel.Roles = string.Join(",", account.Account2Role.Select(x => x.Role.name).ToArray());
                        WrappedPrincipal serializePrincipal = new WrappedPrincipal(
                            id:account.ID,
                            email:account.Email,
                            name:account.Name,
                            roles: string.Join(",", account.Account2Role.Select(x => x.Role.name).ToArray())
                            );
                        string userData = JsonConvert.SerializeObject(serializePrincipal);

                        FormsAuthenticationTicket authTicket = null;
                        var expiration = model.IsRemember == "1" ? DateTime.Now.AddDays(15) : DateTime.Now.AddHours(3);
                        authTicket = new FormsAuthenticationTicket(1, account.Email, DateTime.Now, expiration, false, userData);
                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = authTicket.Expiration, Path = "/" };

                        Session["userAuth"] = JsonConvert.SerializeObject(
                            _accountService.AuthRole(
                                account.Account2Role.Select(x => x.Role.name).ToList(), 
                                Server.MapPath("~/menu_all.xml")));  //為了生成SessionId
                        Response.Cookies.Add(faCookie);
                        #region 紀錄登入資訊

                        Log(account.Name + "  Login", FunctionType.Login, account.Name);
                        #endregion

                        if (string.IsNullOrWhiteSpace(ReturnUrl))
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(ReturnUrl);

                    }

                
            }

            return View(model);
        }
    }
}