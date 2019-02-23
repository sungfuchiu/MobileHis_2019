using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Report
{
    public struct Bi_SyndromicSurveillanceReport
    {
        public Dictionary<string, int> Pie { get; set; }
        public List<SyndromicSurveillanceReport> Line { get; set; }

    }
    public struct SyndromicSurveillanceReport
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public int Threshold { get; set; }
        public List<SyndromicSurveillanceReportDetail> Detail { get; set; }
    }
    public struct SyndromicSurveillanceReportDetail
    {
        public string Date { get; set; }
        public int Cnt { get; set; }
    }
    public struct SyndromicSurveillanceDashboard
    {
        public string Name { get; set; }

        public int LastWeek { get; set; }
        public int ThisWeek { get; set; }
        public int Threshold { get; set; }
        public bool AboveThreshold { get; set; }
    }
    public struct SyndromicSurveillanceExportModel
    {
        public string HospialNo { get; set; }
        public int Diarrhea { get; set; }
        public int ILI { get; set; }
        public int Prolonged_Fever { get; set; }
        public int AFR { get; set; }
        public int None { get; set; }
        public string CreatedAt { get; set; }
    }
}
