using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ApiModel
{
    public class GetNewsResponse
    {
        public int id { get; set; }
        public DateTime PublishStart { get; set; }
        public string Title { get; set; }
    }
}
