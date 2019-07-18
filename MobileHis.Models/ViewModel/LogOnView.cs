
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
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Password")]
        [Required]
        public string Password { get; set; }
        public string IsRemember { get; set; }
        public string BackgroundIMG { get; set; }

        public string HospitalName { get; set; }
        public List<string> PartnerPathList { get; set; }
    }
}