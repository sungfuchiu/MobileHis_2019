
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class RegistrationDeptCateView
    {

        public string ItemDescription { get; set; }
        public List<RegistrationDeptView> depts { get; set; }
      
    }

    public class RegistrationDeptView
    {
        public int ID { get; set; }
        public string DepNo { get; set; }
        public int Category { get; set; }
        public string DepName { get; set; }


    }

}