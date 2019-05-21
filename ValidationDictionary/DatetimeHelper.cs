using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DatetimeHelper
    {
        public static string CultureDateTime(this DateTime? dt)
        {
            string rtnString = "";
            if (dt.HasValue)
            {
                rtnString = dt.Value.ToString(CultureDateTimeFormat());
            }
            return rtnString;
        }
        public static string CultureDateTimeFormat(bool ByJs = false, bool datetimePicker = false)
        {
            var DateTimePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " HH:mm:ss";
            if (datetimePicker) return CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToUpper() + " HH:mm:ss";
            if (ByJs) DateTimePattern = DateTimePattern.Replace("M", "m");
            return DateTimePattern;
        }
    }
}
