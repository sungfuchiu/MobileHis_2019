
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class DepartmentListView
    {
        public int ID { get; set; }
        public int Category { get; set; }
        public int Unit { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }

        public string DepNo { get; set; }


        public string DepName { get; set; }

        public string IsRegistered { get; set; }     
      
        public DateTime? ModDate { get; set; }

   
        public string ModUser { get; set; }
    }
}