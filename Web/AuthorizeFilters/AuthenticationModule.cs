using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MobileHis_2019.AuthorizeFilters
{
    public class AuthenticationModule : IHttpModule
    {
        private const int AUTHENTICATION_TIMEOUT = 20;

        public AuthenticationModule()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(Context_AuthenticateRequest);
        }

        public void Dispose()
        {
            // Nothing here    
        }

        //登录时 验证用户时使用
        public bool AuthenticateUser(string username, string password, bool persistLogin)
        {
            //数据访问类
            CoreRepository cr = (CoreRepository)HttpContext.Current.Items["CoreRepository"];
            string hashedPassword = Encryption.StringToMD5Hash(password);
            try
            {
                //通过用户名密码得到用户对象
                User user = cr.GetUserByUsernameAndPassword(username, hashedPassword);
                if (user != null)
                {
                    user.IsAuthenticated = true;
                    //string currentIp = HttpContext.Current.Request.UserHostAddress;
                    //user.LastLogin = DateTime.Now;
                    //user.LastIp = currentIp;
                    // Save login date and IP 记录相关信息
                    cr.UpdateObject(user); 更新用户授权通过信息
                    // Create the authentication ticket
                    HttpContext.Current.User = new CuyahogaPrincipal(user);  //通过授权
                    FormsAuthentication.SetAuthCookie(user.Name, persistLogin);
                    return true;
                }
                else
                {
                    //log.Warn(String.Format("Invalid username-password combination: {0}:{1}.", username, password));
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Unable to log in user '{0}': " + ex.Message, username), ex);
            }
        }

        /// <summary>
        /// Log out the current user.注销用户
        /// </summary>
        public void Logout()
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
        }

        private void Context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Context.User != null && app.Context.User.Identity.IsAuthenticated)//若用户已经通过认证
            {
                CoreRepository cr = (CoreRepository)HttpContext.Current.Items["CoreRepository"];
                int userId = Int32.Parse(app.Context.User.Identity.Name);
                User cuyahogaUser = (User)cr.GetObjectById(typeof(User), userId);//得到对应的cuyahogaUser对象
                cuyahogaUser.IsAuthenticated = true;
                app.Context.User = new CuyahogaPrincipal(cuyahogaUser);//将通过标准窗体认证的user替换成CuyahogaUser, cuyahogaUser包含更多的信息
            }
        }

    }