using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Web;

namespace MobileHis_2019.AuthorizeFilters
{
    public class CustomPrincipal : IPrincipal
    {
        private User _user;

        // 返回一个现实IIdentity接口的user对象
        public IIdentity Identity
        {
            get => _user;
        }

        // 当前用户是否属于指定角色 在以后的权限认证中可以使用 也可以使用User类中的相关方法来代替
        public bool IsInRole(string role)
        {
            foreach (var inRole in _user.Roles)
            {
                if (inRole.Equals(role))
                    return true;
            }

            return false;
        }

        ///初始化 若user通过授权则创建
        public CustomPrincipal(User user)
        {
            if (user != null && user.IsAuthenticated)
            {
                _user = user;
            }
            else
            {
                throw new SecurityException("Cannot create a principal without u valid user");
            }
        }

    }
}