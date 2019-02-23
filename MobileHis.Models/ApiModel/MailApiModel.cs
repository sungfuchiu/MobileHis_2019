using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ApiModel
{
    public class MailApiRequest
    {
        public string name { get; set; }
        public string mail { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
    }
    public class MailApiResponse
    {
        public bool success { get; set; }
        public int status { get; set; }
        public string msg { get; set; }
    }
}
