using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ApiModel
{

    public class FingerApi
    {
        public string id { get; set; }
        public string Patient_FirstName { get; set; }
        public string Patient_LastName { get; set; }

        public string Patient_Gender { get; set; }
        public string Patient_id { get; set; }
        public string Patient_FingerData { get; set; }
        public string Patient_FingerImageData { get; set; }
    }


    public class PostDataFingerApi
    {
        public string action
        {
            get;
            set;
        }

        public string apikey
        {
            get;
            set;
        }

        public string data
        {
            get;
            set;
        }
    }
}