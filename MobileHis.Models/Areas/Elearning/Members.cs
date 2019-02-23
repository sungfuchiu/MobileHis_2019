using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Elearning
{
    public class Members
    {
        public int ID { get; set; }

        public string Member { get; set; }
       
        public string Name { get; set; }
        public string Dept { get; set; }

        public string MemberType { get; set; }
    }
}