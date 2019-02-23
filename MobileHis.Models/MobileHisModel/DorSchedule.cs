using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models
{
    public enum ScheduleShift {
        Morning, Afternoon, Night
    }

    public partial class DorSchedule
    {
        private static Dictionary<ScheduleShift, string> ScheduleShiftMap = new Dictionary<ScheduleShift,string>() {
            {ScheduleShift.Morning, "1"},
            {ScheduleShift.Afternoon, "3"},
            {ScheduleShift.Night, "5"}
        };

        public static string GetShiftStr(ScheduleShift s)
        {
            string val;
            return ScheduleShiftMap.TryGetValue(s, out val) ? val : "";
        }

        public ScheduleShift Shift
        {
            get
            {
                var keys = ScheduleShiftMap.Where(p => p.Value == ShiftNo).Select(p => p.Key);
                return keys.Any() ? keys.First() : ScheduleShift.Morning;
            }
            set
            {
                ShiftNo = GetShiftStr(value);
            }
        }
    }
}