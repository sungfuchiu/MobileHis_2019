using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models
{
    public class BaseSearchModel
    {
        int? page;
        public int Page
        {
            get => page ?? 1;
            set => page = value;
        }
        public string Keyword { get; set; }
    }
}
