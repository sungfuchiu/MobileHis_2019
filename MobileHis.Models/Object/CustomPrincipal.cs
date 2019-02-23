using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Principal;
namespace MobileHis.Models.Object
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (!string.IsNullOrEmpty(roles))
            {                
                if (roles.Split(',').Any(r => role.Contains(r)))                
                    return true;                
                else                
                    return false;                
            }
            else
                return false;
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string roles { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string roles { get; set; }
    }
}