using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int PageTotal { get; set; }
        public int PageSize { get; set; }
    }
}