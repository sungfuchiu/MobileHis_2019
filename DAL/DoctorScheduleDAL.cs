using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace DAL
{
    public class DoctorScheduleDAL
    {
        public static Dictionary<ScheduleShift, string> ScheduleShiftMap = new Dictionary<ScheduleShift, string>() {
            {ScheduleShift.Morning, "1"},
            {ScheduleShift.Afternoon, "3"},
            {ScheduleShift.Night, "5"}
        };
    }
}
