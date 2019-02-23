using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class GetRoomItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool inUse { get; set; }
    }
}
