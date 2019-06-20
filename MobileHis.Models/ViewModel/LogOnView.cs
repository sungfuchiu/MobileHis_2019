
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class LogOnView
    {
        [Display(ResourceType = typeof(Resource), Name = "Account_Email")]       
        [Required]
        public string login_email { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Password")]
        [Required]
        public string login_password { get; set; }
        public string login_remember { get; set; }
        public string BK_img { get; set; }

        public string HospitalName { get; set; }
        public List<string> PartnerPathList { get; set; }
    }
}