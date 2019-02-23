using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class VM_TreeMenu
    {
        public int id { get; set; }
        public int pId { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        public string url { get; set; }
        public string target { get; set; }
    }
}