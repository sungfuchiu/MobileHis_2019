using MobileHis.Comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobileHis.Models.MobileHisModel
{
    public class UserSampleModel
    {
        private string _PassWord = string.Empty;
        private DateTime _ChangedDate = DateTime.MinValue;
        private string _Status = string.Empty;
        private int _Role = 1;

        public UserSampleModel()
        {
            _PassWord = System.Web.Configuration.WebConfigurationManager.AppSettings["defaultImportPwd"];
            _ChangedDate = System.DateTime.Now;
            _Status = "01";
        }
        [SchemaMapping("UserName", IsRequired = true)]
        public string UserName { get; set; }
        [SchemaMapping("Email", IsRequired = true, Regular = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardNumber { get; set; }

        [SchemaMapping("Gender", Format= "M,F")]
        public string Gender { get; set; }

        public DateTime Birthday { get; set; }
        public int? Department { get; set; }

        public int? JobTitle { get; set; }

        public int Role
        {
            get
            {
                return _Role;
            }
            set
            {
                if (value < 1)
                {
                    _Role = 1;
                }
                else
                {
                    _Role = value;
                }
            }
        }
        [SchemaMapping("IsDoctor", Format= " ,Y")]
        public string IsDoctor { get; set; }

        public string Password
        {
            get
            {
              return _PassWord;
            }
            set { }
        }
        public DateTime CreateDate
        {
            get
            {
                return _ChangedDate;
            }
            set { }
        }
        public DateTime ModDate
        {
            get
            {
                return _ChangedDate;
            }
            set { }

        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set { }
        }
       
    }
}