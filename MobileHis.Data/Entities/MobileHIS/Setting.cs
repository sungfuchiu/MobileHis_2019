using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
    [NotMapped]
    public class DefaultSettings
    {
        public string FingerPrint { get; set; }
        public string Pacs { get; set; }
        public string ConsultationFee { get; set; }
        public string BK_img { get; set; }
        public string Partner1 { get; set; }
        public string Official_Banner_Img { get; set; }
        public string Official_Logo_Img { get; set; }
        public string Opd_Shift_Morning { get; set; }
        public string Opd_Shift_Afternoon { get; set; }
        public string Opd_Shift_Night { get; set; }
        public string ApiKey { get; set; }
    }
    [NotMapped]
    public class DefaultSetting
    {
        private ShiftTime morningShift;
        private ShiftTime afternoonShift;
        private ShiftTime nightShift;
        private ImageFile _BKImage;
        private ImageFile bannerImage;
        private ImageFile logoImage;
        private HttpRequestBase partnerFile;
        public string FingerPrint { get; set; }
        public string Pacs { get; set; }
        public string ConsultationFee { get; set; }
        public HttpPostedFileBase BK_img_file { get; set; }
        public HttpPostedFileBase Official_Banner_Img_file { get; set; }
        public HttpPostedFileBase Official_Logo_Img_file { get; set; }
        public string BK_img { get; set; }
        public string Official_Banner_Img { get; set; }
        public string Official_Logo_Img { get; set; }
        public string Opd_Shift_Morning_Start { get; set; }
        public string Opd_Shift_Morning_End { get; set; }
        public string Opd_Shift_Afternoon_Start { get; set; }
        public string Opd_Shift_Afternoon_End { get; set; }
        public string Opd_Shift_Night_Start { get; set; }
        public string Opd_Shift_Night_End { get; set; }
        public string Opd_Shift_Morning { get; set; }
        public string Opd_Shift_Afternoon { get; set; }
        public string Opd_Shift_Night { get; set; }
        public string Partner_Img { get; set; }
        public string ApiKey { get; set; }
        public HttpRequestBase PartnerFile
        {
            get; set;
            //get
            //{
            //    return partnerFile;
            //}
            //set
            //{
            //    if ( value.Files["Partner_file"] != null && value.Files["Partner_file"].ContentLength > 0)
            //    {
            //        var files = value.Files.GetMultiple("Partner_file");

            //        using (SettingDAL settingDAL = new SettingDAL())
            //        {
            //            var partnerImage = settingDAL.GetEmptyPartnerImgSetting();
            //            var cnt = 0;
            //            foreach (var file in files)
            //            {
            //                if (file != null)
            //                {
            //                    var fileName = new System.IO.FileInfo(file.FileName).Name;
            //                    var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
            //                    fileName = s.Write(fileName, file);
            //                    partnerImage[cnt].Value = fileName;
            //                    settingDAL.Edit(partnerImage[cnt]);
            //                    cnt++;

            //                }
            //            }
            //            settingDAL.Save();
            //        }
            //    }
            //    partnerFile = value;
            //}
        }
        public ImageFile BKImage
        {
            get
            {
                _BKImage.ColumnName = "BK_img_file";
                return _BKImage;
            }
            set
            {
                _BKImage = value;
            }
        }
        public ImageFile BannerImage
        {
            get
            {
                bannerImage.ColumnName = "Official_Banner_Img_file";
                return bannerImage;
            }
            set
            {
                bannerImage = value;
            }
        }
        public ImageFile LogoImage
        {
            get
            {
                logoImage.ColumnName = "Official_Logo_Img_file";
                return logoImage;
            }
            set
            {
                logoImage = value;
            }
        }
        public ShiftTime MorningShift
        {
            get
            {
                morningShift.ColumnName = "Opd_Shift_Morning";
                return morningShift;
            }
            set
            {
                morningShift = value;
            }
        }
        public ShiftTime AfternoonShift
        {
            get
            {
                afternoonShift.ColumnName = "Opd_Shift_Afternoon";
                return afternoonShift;
            }
            set
            {
                afternoonShift = value;
            }
        }
        public ShiftTime NightShift
        {
            get
            {
                nightShift.ColumnName = "Opd_Shift_Night";
                return nightShift;
            }
            set
            {
                nightShift = value;
            }
        }
        public class ImageFile : ObjectData
        {
            public ImageFile(HttpPostedFileBase imageFileBase) { ImageFileBase = imageFileBase; }
            private HttpPostedFileBase _imageFileBase;
            public HttpPostedFileBase ImageFileBase
            {
                get => _imageFileBase;
                set
                {
                    //if (value != null)
                    //{
                    //    _imageFileBase = value;
                    //    ImageFileName = value.FileName;
                    //    var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);
                    //    ImageFileName = s.Write(ImageFileName, value);
                    //}
                }
            }
            public string ImageFileName { get; set; }
            public string ColumnName { get; set; }

            public string ColumnValue()
            {
                return ImageFileName;
            }
        }
        public class ShiftTime : ObjectData
        {
            public DateTime? BeginTime { get; set; }
            public DateTime? EndTime { get; set; }
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

            public string ColumnName { get; set; }

            public string ColumnValue()
            {
                return BeginTime.Value.ToString("HHmm") + '-' + EndTime.Value.ToString("HHmm");
            }
        }
        public interface ObjectData
        {
            string ColumnName { get; set; }
            string ColumnValue();
        }
    }
    [NotMapped]
    public class InfoSettings
    {
        //public HttpRequestBase EnvironmentFile { get; set; }
        public string Hospital_No { get; set; }
        public string Hospital_Name { get; set; }
        public string Hospital_Tel { get; set; }
        public string Hospital_Address { get; set; }
        public string Hospital_Contact_Name { get; set; }
        public string Hospital_Contact_Tel { get; set; }
        public string Hospital_About { get; set; }
        public string Hospital_lat { get; set; }
        public string Hospital_lng { get; set; }
        public string Hospital_Environment { get; set; }
        public string Hospital_Slogan { get; set; }
    }
    [NotMapped]
    public class MailSettings
    {
        public string Mail_UserName { get; set; }
        public string Mail_UserPassword { get; set; }
        public string Mail_Port { get; set; }
        public string Mail_Url { get; set; }
        public string Mail_ContactMail { get; set; }
        public string Mail_ContactBccMail { get; set; }
    }
    [NotMapped]
    public class OtherSettings
    {
        public string UPIS_APIKEY { get; set; }
        public string UPIS_IP { get; set; }
        public string SymptomShot { get; set; }
        public string SymptomShotIP { get; set; }
        public string SymptomShot_3DesKey { get; set; }
        public string SymptomShot_3DesIv { get; set; }
        public string SmartHealth_APIKEY { get; set; }
        public string SmartHealth_IP { get; set; }
        public string SmartHealth_Register_IP { get; set; }
        public string SmartHealth_3DesKey { get; set; }
        public string SmartHealth_3DesIv { get; set; }

        public string Owl_APIKEY { get; set; }
        public string Owl_IP { get; set; }
        public string Owl_3DesKey { get; set; }
        public string Owl_3DesIv { get; set; }
        public string Lab_IP { get; set; }
    }
}
