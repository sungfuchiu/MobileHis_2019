using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class ImportDataViewModel
    {
        public string Area { get; set; }
        public string Controller { get; set; }

        public string Action { get; set; }
    }
}