
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class RoomListView
    {
        public int ID { get; set; }

        public string RoomNo { get; set; }
      
        public string RoomName { get; set; }

      
        public string AllowDeptName { get; set; }
        
        public string AllowDeptNoList { get; set; }
      
        public int? RoomMax { get; set; }

      
        public DateTime? ModDate { get; set; }

   
        public string ModUser { get; set; }
    }
}