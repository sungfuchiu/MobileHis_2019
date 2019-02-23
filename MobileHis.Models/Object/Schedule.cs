using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Object
{
    public class ScheduleObj
    {
        public bool allDay = false;
        public DateTime dstart { get; set; }public DateTime dend { get; set; }
        private string surl;
        public string title { get; set; }
        public string start { get { return dstart.ToString("s"); } }
        public string end { get { return dend.ToString("s"); } }
        public string url
        {
            get { return surl + "/" + courseId.ToString(); }
            set { surl = value; }
        }
        public int courseId { get; set; }
    }
}
