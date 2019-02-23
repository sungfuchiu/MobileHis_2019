using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ApiModel
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
    }
    #region online reg
    public struct LoadCalendarResponse
    {
        public List<DeptResponse> depts { get; set; }
        public string dateFormat { get { return MobileHis.Comm.DateTimeHelper.CultureDateFormat().ToUpper(); } }
    }
    public struct DeptResponse
    {
        public string key { get; set; }
        public string val { get; set; }
    }

    public struct GetScheduleListRequest
    {
        [Required]
        public string deptId { get; set; }
        [Required]
        public string shiftNo { get; set; }
        /// <summary>
        /// format: YYYY-MM-DD
        /// </summary>
        [Required]
        public string start { get; set; }
        /// <summary>
        /// format: YYYY-MM-DD
        /// </summary>
        [Required]
        public string end { get; set; }
    }
    public struct GetScheduleListResponse
    {
        public List<GetScheduleListModel> events { get; set; }
    }
    public struct GetScheduleListModel
    {
        public string start { get; set; }
        public bool allDay { get; set; }
        public string title { get; set; }
        public string shiftNo { get; set; }
        public int accountId { get; set; }
        public int deptId { get; set; }
        public int roomId { get; set; }
    }
    public struct GetRoomInforRequest
    {
        /// <summary>
        /// format: YYYY-MM-DD
        /// </summary>
        public string schDate { get; set; }
        public int accountId { get; set; }
        public string deptId { get; set; }
        public string shiftNo { get; set; }
        public int roomId { get; set; }
    }
    public struct GetRoomInforResponse
    {
        public GetRoomInforModel result { get; set; }
    }
    public struct GetRoomInforModel
    {
        public string schDate { get; set; }
        public string shiftNo { get; set; }
        public string shiftNoName { get; set; }
        public int deptId { get; set; }
        public int accountId { get; set; }
        public string patientId { get; set; }
        public string patientName { get; set; }
        public string dorName { get; set; }
        public int roomId { get; set; }
        public string roomNo { get; set; }
        public int roomMax { get; set; }
        public string roomName { get; set; }
        public int regCount { get; set; }
        public int doctorId { get; set; }
        public bool showTriage { get; set; }
        #region ss
        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
        #endregion

    }
    public struct ValidateRequest
    {
        // public string nationalId { get; set; }
        public string hospitalNo { get; set; }
        public string birth { get; set; }
        public string opdDate { get; set; }
        public int? deptId { get; set; }
        public int roomId { get; set; }
        public string shiftNo { get; set; }
        public int doctorId { get; set; }
    }
    public struct ValidateResponse
    {
        public bool valid { get; set; }
        public string msg { get; set; }
    }
    public struct CreateRegRequest
    {
        public string opdDate { get; set; }
        public int? deptId { get; set; }
        public int roomId { get; set; }
        public string shiftNo { get; set; }
        public string patientId { get; set; }
        public string nationalId { get; set; }
        public string firstName { get; set; }
        public string midName { get; set; }
        public string surname { get; set; }
        public string birthday { get; set; }
        public int doctorId { get; set; }
        public string remark { get; set; }
    }
    public class CreateRegResponse : BaseResponse
    {
        //public bool success { get; set; }
        //public string status { get; set; }
        //public string msg { get; set; }
    }
    #endregion
    #region cancel
    public struct CancelRequest
    {
        //public string nationalId { get; set; }
        public string hospitalNo { get; set; }
        public string birth { get; set; }
    }
    public class CancelResponse : BaseResponse
    {
        //public bool success { get; set; }
        //public string msg { get; set; }
        public CancelData data { get; set; }

    }
    public struct CancelData
    {
        public CancelPatient patient { get; set; }
        public List<CancelList> list { get; set; }
    }
    public struct CancelPatient
    {
        public string firstName { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public int age { get; set; }
        public string blood { get; set; }
        public string patientId { get; set; }
        public string nationalId { get; set; }
        public string insurance { get; set; }
    }
    public struct CancelList
    {
        public int id { get; set; }
        public string opdDate { get; set; }
        public string shiftNo { get; set; }
        public string shiftName { get; set; }
        public string dept { get; set; }
        public string roomNo { get; set; }
        public string room { get; set; }
        public string doc { get; set; }
        public int seq { get; set; }
    }
    public struct DelRegRequest
    {
        public int id { get; set; }
    }
    public class DelRegResponse : BaseResponse
    {
        //public bool success { get; set; }
        //public string msg { get; set; }
    }
    #endregion
    #region index
    public struct IndexLoadResponse
    {
        /// <summary>
        /// Hospital_Name
        /// </summary>
        public string hospitalName { get; set; }
        public string hospitalTel { get; set; }
        public string hospitalAddress { get; set; }
        public string hospitalLat { get; set; }
        public string hospitalLng { get; set; }
        public string hospitalAbout { get; set; }
        public string hospitalOpenTime { get; set; }
        public string hospitalSlogan { get; set; }

        public string email { get; set; }
        public string bannerPath { get; set; }
        public string logoPath { get; set; }
        public string opdShiftMorningStart { get; set; }
        public string opdShiftMorningEnd { get; set; }
        public string opdShiftAfternoonStart { get; set; }
        public string opdShiftAfternoonEnd { get; set; }
        public string opdShiftNightStart { get; set; }
        public string opdShiftNightEnd { get; set; }
        public string opdShiftMorningName { get { return LocalRes.Resource.Comm_Morning; } }
        public string opdShiftAfternoonName { get { return LocalRes.Resource.Comm_Afternoon; } }
        public string opdShiftNightName { get { return LocalRes.Resource.Comm_Night; } }
        public bool mailUrlIsSet { get; set; }
        public List<DoctorGrps> doctorlist { get; set; }
        public List<string> hospitalEnvrionmentImage { get; set; }

    }

    public struct DoctorGrps
    {
        public string deptname {get;set;}
        public List<IndexDoctor> doctors { get; set; }
    }
    public struct IndexDoctor
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string major { get; set; }
        public string exp { get; set; }
        public string imgPath { get; set; }
        public string expertise { get; set; }
       
    }
    public class IndexDoctorResponse : BaseResponse
    {
        //public bool success { get; set; }
        //public string status { get; set; }
        //public string msg { get; set; }
        public IndexDoctor doctor { get; set; }
    }
    #endregion

    public struct ImageResponse
    {
        public string type { get; set; }
        public string img { get; set; }
    }
}
