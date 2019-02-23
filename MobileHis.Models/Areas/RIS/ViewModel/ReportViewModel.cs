using System;
using MobileHis.Data;

namespace MobileHis.Models.Areas.RIS.ViewModels
{
    public class ReportViewModel
    {
        public Patient patient { get; set; }
        public Guid ExamID { get; set; }
        public ExamReport report { get; set; }

    }

}