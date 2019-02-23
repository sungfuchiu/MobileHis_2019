using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace MobileHis.Models.Areas.MedicalRecord
{
    public class MedicalRecordViewModel
    {
        public int MedicalRecordID { get; set; }
        public string PatientID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string SurName { get; set; }
        public int? CallNo { get; set; }
        public string DeptName { get; set; }
        public bool PullOut { get; set; }
        public bool PullIn { get; set; }
        public DateTime? PullOutDateTIme { get; set; }
        public DateTime? PullInDateTIme { get; set; }
        public string Clinic { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PatientName
        {
            get
            {
                return this.FirstName + " " + this.MidName + " " + this.SurName;
            }
        }

    }

    public class MedicalRecordReport
    {
        public string UserName { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string DateRange { get; set; }
        public int totalClinicsRow { get; set; }
        public List<DayShiftLoggedClinic> Clinics { get; set; }

    }
    public class DayShiftLoggedClinic
    {
        public string Name { get; set; }
        public List<DayShiftLoggedModel> List { get; set; }
        public int totalCnt { get; set; }
    }
    public class DayShiftLoggedModel
    {
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string Time { get; set; }
        public bool ChartStatus_Out { get; set; }
        public bool ChartStatus_In { get; set; }

    }

}
