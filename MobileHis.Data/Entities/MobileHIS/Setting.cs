using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? ParentId { get; set; }

        public string SettingName { get; set; }

        public string Value { get; set; }

        public bool Deletable { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        #region ForeignKey
        [ForeignKey("ParentId")]
        public virtual Setting ParentSetting { get; set; }
        /// <summary>
        /// created by account
        /// </summary>
        [ForeignKey("CreatedBy")]
        public virtual Account Account { get; set; }
        #endregion

        #region iCollection
        public virtual ICollection<Setting> Settings { get; set; }
        #endregion

        public class ShiftTime
        {
            public DateTime? BeginTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string ErrorMSG { get; set; }
            public void SetShiftTimeWithString(string timeString)
            {
                var timePeriod = timeString.Split('-');
                BeginTime = ReturnTimeByFourDigit(timePeriod[0]);
                EndTime = ReturnTimeByFourDigit(timePeriod[1]);
            }
            private DateTime? ReturnTimeByFourDigit(string fourDigit)
            {
                var parseFormat = "yyyy-MM-dd HH:mm";
                DateTime dateTime = new DateTime();
                if (DateTime.TryParseExact(
                       DateTime.Now.ToString("yyyy-MM-dd") + fourDigit
                       , parseFormat
                       , CultureInfo.InvariantCulture
                       , DateTimeStyles.None
                       , out dateTime))
                    return dateTime;
                else
                    return null;
            }
            public string GetShiftTimeString()
            {
                return BeginTime.Value.ToString("HHmm") + '-' + EndTime.Value.ToString("HHmm");
            }
            public bool IsShiftTimeNotNull()
            {
                return BeginTime.HasValue && EndTime.HasValue;
            }
            public bool InThePeriod(DateTime time)
            {
                return ((time >= BeginTime && time <= EndTime) || time < BeginTime);
            }
        }
    }
}
