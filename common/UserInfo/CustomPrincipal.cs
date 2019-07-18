using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Common.UserInfo;

namespace Common
{
    [Serializable]
    public class WrappedPrincipal
    {
        public WrappedPrincipal(IPrincipal principal)
        {
            Principal = principal;
        }

        public WrappedPrincipal(int id, string email, string name, string roles)
        {
            ID = id;
            Email = email;
            Name = name;
            Roles = roles;
        }
        public IPrincipal Principal { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
    }

}
