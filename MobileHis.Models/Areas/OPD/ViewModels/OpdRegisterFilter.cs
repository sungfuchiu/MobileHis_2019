using System;
using System.Linq;
using MobileHis.Data;

namespace MobileHis.Models.Areas.OPD.ViewModels
{


    public class OpdRegisterFilter : MobileHis.Models.PageFilter
    {
        public ScheduleShift CurrentShift { get; set; }

        public ScheduleShift? Shift { get; set; }

        public int DoctorID { get; set; }

        public Account Doctor { get; set; }

        public DateTime? OptDate { get; set; }

        public string patientid { get; set; }

        public OpdStatusEnum? OpdStatus { get; set; }

        //public IOrderedQueryable<MobileHis.Data.OpdRegister> Filter(IQueryable<OpdRegister> Query)
        //{
        //    var shift_symbol = DorSchedule.GetShiftStr(Shift ?? CurrentShift);

        //    Query = Query.Where(q => q.DorSchedule.AccountID == Doctor.ID);
        //    Query = Query.Where(q => q.DorSchedule.ShiftNo == shift_symbol);
        //    Query = Query.Where(q => q.DorSchedule.SchDate == (OptDate ?? DateTime.Today));
        //    if (OpdStatus != null)
        //    {
        //        var status_symbol = OpdRegister.GetOpdStatus((OpdStatusEnum)OpdStatus);
        //        Query = Query.Where(q => q.OpdStatus == status_symbol);
        //    }

        //    return Query.OrderBy(q => q.Seq);


        //}
    }
}