using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Report
{
    public class ApplicationReportModel
    {
        public string HospitalNo { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Doctor { get; set; }
        public string Shift { get; set; }
        public string Status { get; set; }
        public string TempSaveTime { get; set; }
        public string SubmitTime { get; set; }
        public string OPDDate { get; set; }
        public string ICD10_1 { get; set; }
        public string ICD10_2 { get; set; }
        public string ICD10_3 { get; set; }
        public string ICD10_4 { get; set; }
    }
    public class Top20Icd10Report
    {
        public string ICD10Code { get; set; }
        public string ICD10Description { get; set; }
        public int TotalCount { get; set; }
    }
    public class Top20AddmissionReport
    {
        public string Ward { get; set; }
        public string Room { get; set; }
        public int Count { get; set; }
    }
}
