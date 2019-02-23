using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ApiModel
{
    public class SmartHealthSetting
    {
        public enum Gender
        {           
            Unknow = 0,         
            Male = 10,            
            Female = 20,            
            Other = 30
        }

        public enum Blood
        {
            Unknow = 0,
            A = 10,
            AB = 20,
            B = 30,
            O = 40,
        }

        public enum AccountOriginType
        {
            Unknow = 0,
            ClientApp = 1,//機台
            MonitorApp = 2, //醫生端程式
            Web = 3 //網站       
        }
        public class preRegister
        {
            public string account { get; set; }
            public string identityno { get; set; }
            public string password { get; set; }
            public string phone { get; set; }
            public Gender? gender { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public Blood? blood { get; set; }
            public string nfcno { get; set; }
            public DateTime? birthday { get; set; }
            public string cardData { get; set; }
            public AccountOriginType origin { get; set; }
            public string origindata { get; set; }
            public byte[] avatar { get; set; }

            public int[] orgids { get; set; }
        }
    }
}