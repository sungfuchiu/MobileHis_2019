using LocalRes;
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class GuardianListView
    {
        public int ID { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public string GuardianName { get; set; }
        public string IsUsed { get; set; }
        public string UseInLobby { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public List<Guardian_File> files_list { get; set; }
    }
}