using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.MedicalRecord
{
    public struct ReceptionListIndexModel
    {
        // public DateTime dCreatedAt { get; set; }
        public DateTime dVisitTime { get; set; }
        public int Id { get; set; }
        public string sPatientName { get; set; }
        public string sPatientId { get; set; }
        public string sDept { get; set; }
        public int? nCallNo { get; set; }
        //public int? nRegId { get; set; }
        //public int? nBookNo { get; set; }
        public DateTime? dPullOutTime { get; set; }
        // public string sShift { get; set; }
        public List<string> appointmentList { get; set; }
    }
    public struct ReceptionListSearchModel
    {
        public string sDate { get; set; }
        public string sPatientId { get; set; }
        public string sKeyword { get; set; }
        public string sClinic { get; set; }
        public bool? bRegisted { get; set; }
    }
    public struct ReceptionUpdateModel
    {
        public int id { get; set; }
        public bool Alcohol { get; set; }
        public bool Injury { get; set; }
        public int? CallNo { get; set; }
        public string EntryTime { get; set; }
        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
    }
    public struct GetReceptionModel
    {
        public int id { get; set; }
        public int? CallNo { get; set; }
        public string VisitDate { get; set; }
        //  public DateTime CreatedDate { get; set; }
        public string Dept { get; set; }
        public string TypeOfVisit { get; set; }
        public bool Alcohol { get; set; }
        public bool Injury { get; set; }
        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
    }

    public struct GetAppointmentList
    {
        public int id { get; set; }
        public string shift { get; set; }
        public string dept { get; set; }
        public int? seq { get; set; }
        public string doctor { get; set; }
        public bool canCancel { get; set; }
    }
    public struct GetAppointmentSlipList
    {
        public int id { get; set; }
        public string date { get; set; }
        public string shift { get; set; }
        public string dept { get; set; }
        public int? seq { get; set; }
        public string doctor { get; set; }
        public bool canCancel { get; set; }
    }
}
