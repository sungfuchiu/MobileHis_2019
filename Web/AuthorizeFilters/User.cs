using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MobileHis_2019.AuthorizeFilters
{
    public class User : IIdentity
    {
        private int _id;
        private string _name;
        private string _email;
        private bool _isAuthenticated;

        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        //是否通过认证
        public virtual bool IsAuthenticated
        {
            get { return this._isAuthenticated; }
            set { this._isAuthenticated = value; }
        }

        public List<string> Roles { get; set; }
        //重写为用户ID
        public virtual string Name
        {
            get => _isAuthenticated ? _name.ToString() : ""; 
        }

        public virtual string AuthenticationType
        {
            get { return "CustomAuthentication"; }
        }

        public User()
        {
            this._id = -1;
            this._isAuthenticated = false;
        }

    }
}