using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Clinical
{
    public interface IHistoryCalendar
    {
        DateTime Date { get; set; }
        string Type { get; }
        string Url(System.Web.Mvc.UrlHelper helper);
    }

    public class OPDHistoryView : IHistoryCalendar
    {
        public DateTime Date { get; set; }

        public string Type
        {
            get { return "OPD"; }
        }
        public int OpdRecordId { get; set; }

        public string Url(System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("ClinicalRecord", "History", new { Id = OpdRecordId, area = "Clinical" });
        }
    }
}