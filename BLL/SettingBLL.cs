using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;
using MobileHis.Data;
using MobileHis.Misc;

namespace BLL
{
    //public class SettingEntity
    //{
    //    HttpPostedFileBase BKImageFile { get; set; }
    //    public class ShiftTime
    //    {
    //        public DateTime? BeginTime { get; set; }
    //        public DateTime? EndTime { get; set; }
    //        public void SetShiftTimeWithString(string timeString)
    //        {
    //            var timePeriod = timeString.Split('-');
    //            BeginTime = ReturnTimeByFourDigit(timePeriod[0]);
    //            EndTime = ReturnTimeByFourDigit(timePeriod[1]);
    //        }
    //        private DateTime? ReturnTimeByFourDigit(string fourDigit)
    //        {
    //            var parseFormat = "yyyy-MM-dd HH:mm";
    //            DateTime dateTime = new DateTime();
    //            if (DateTime.TryParseExact(
    //                   DateTime.Now.ToString("yyyy-MM-dd") + fourDigit
    //                   , parseFormat
    //                   , CultureInfo.InvariantCulture
    //                   , DateTimeStyles.None
    //                   , out dateTime))
    //                return dateTime;
    //            else
    //                return null;
    //        }
    //        public string GetShiftTimeString()
    //        {
    //            return BeginTime.Value.ToString("HHmm") + '-' + EndTime.Value.ToString("HHmm");
    //        }
    //        public bool IsShiftTimeNotNull()
    //        {
    //            return BeginTime.HasValue && EndTime.HasValue;
    //        }
    //        public bool InThePeriod(DateTime time)
    //        {
    //            return ((time >= BeginTime && time <= EndTime) || time < BeginTime);
    //        }
    //    }
    public class SettingBLL
    {
        //private SettingDAL settingDAL = new SettingDAL();

        public bool SetGeneralSetting(GeneralSettings settings)
        {

            //if (settings.BK_img_file != null)
            //{
            //    var fileName = settings.BK_img_file.FileName;
            //    var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);

            //    fileName = s.Write(fileName, settings.BK_img_file);

            //    settings.BK_img = fileName;
            //}
            //if (settings.Official_Banner_Img_file != null)
            //{
            //    var fileName = settings.Official_Banner_Img_file.FileName;
            //    var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
            //    fileName = s.Write(fileName, settings.Official_Banner_Img_file);

            //    settings.Official_Banner_Img = fileName;
            //}
            //if (settings.Official_Logo_Img_file != null)
            //{
            //    var fileName = settings.Official_Logo_Img_file.FileName;
            //    var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
            //    fileName = s.Write(fileName, settings.Official_Logo_Img_file);

            //    settings.Official_Logo_Img = fileName;
            //}

            //#region shift
            //if ((settings.Opd_Shift_Morning_Start != null) && (settings.Opd_Shift_Morning_End != null))
            //{
            //    settings.Opd_Shift_Morning = settings.Opd_Shift_Morning_Start + "-" + settings.Opd_Shift_Morning_End;
            //}

            //if ((settings.Opd_Shift_Afternoon_Start != null) && (settings.Opd_Shift_Afternoon_End != null))
            //{
            //    settings.Opd_Shift_Afternoon = settings.Opd_Shift_Afternoon_Start + "-" + settings.Opd_Shift_Afternoon_End;
            //}

            //if ((settings.Opd_Shift_Night_Start != null) && (settings.Opd_Shift_Night_End != null))
            //{
            //    settings.Opd_Shift_Night = settings.Opd_Shift_Night_Start + "-" + settings.Opd_Shift_Night_End;
            //}
            //#endregion
            Update(SettingTypes.Default, settings);
            //for mutli file upload
            if (settings.PartnerFile.Files["Partner_file"] != null && settings.PartnerFile.Files["Partner_file"].ContentLength > 0)
            {
                var files = settings.PartnerFile.Files.GetMultiple("Partner_file");

                using (SettingDAL settingDAL = new SettingDAL())
                {
                    var partnerImage= settingDAL.GetEmptyPartnerImgSetting();
                    var cnt = 0;
                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            var fileName = new System.IO.FileInfo(file.FileName).Name;
                            var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                            fileName = s.Write(fileName, file);
                            partnerImage[cnt].Value = fileName;
                            settingDAL.Edit(partnerImage[cnt]);
                            cnt++;

                        }
                    }
                    settingDAL.Save();
                }
            }
            return true;
        }

        public bool SetInfoSetting(InfoSettings settings)
        {
            if (settings.EnvironmentFile.Files["Environment_file"] != null && settings.EnvironmentFile.Files["Environment_file"].ContentLength > 0)
            {
                var files = settings.EnvironmentFile.Files.GetMultiple("Environment_file");
                foreach (var file in files)
                {
                    if (file != null)
                    {
                        var fileName = new System.IO.FileInfo(file.FileName).Name;
                        var s = MobileHis.Misc.Storage.GetStorage(StorageScope.HospitalEnvironment);

                        fileName = s.Write(fileName, file);
                        if (!string.IsNullOrEmpty(settings.Hospital_Environment)) settings.Hospital_Environment += ";";
                        settings.Hospital_Environment += fileName;

                    }
                }
            }
            Update(SettingTypes.Info, settings);
            return true;
        }
        public bool SetOtherSetting(OtherSettings settings)
        {

            Update(SettingTypes.Other, settings);
            return true;
        }
        public bool SetMailSetting(MailSettings settings)
        {
            Update(SettingTypes.Mail, settings);
            return true;
        }

        void Update(SettingTypes type, object data)
        {
            using (SettingDAL settingDAL = new SettingDAL())
            {
                foreach (var prop in data.GetType().GetProperties())
                {
                    //挑出六個尚未合成的時段設定不要進入資料庫比較(尾巴下底線_是重要依據不可刪除)
                    if (!prop.Name.Contains("Opd_Shift_Morning_") && !prop.Name.Contains("Opd_Shift_Afternoon_") && !prop.Name.Contains("Opd_Shift_Night_")
                        //not post files
                        && prop.PropertyType.Name != "HttpPostedFileBase")
                    {
                        if (!prop.Name.Contains("Partner"))
                        {
                            settingDAL.Update(prop.Name, type, Convert.ToString(prop.GetValue(data, null)));
                        }
                    }
                }
            }
        }
        public ScheduleShift GetCurrentShift()
        {
            var shifts = new List<Setting>();
            using (SettingDAL settingDAL = new SettingDAL())
            {
                shifts = settingDAL.GetShiftList();
            }
            Setting.ShiftTime morningShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime afternoonShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime dinnerShiftTime = new Setting.ShiftTime();

                morningShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Morning").Value);
                afternoonShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Afternoon").Value);
                dinnerShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Night").Value);

            switch (DateTime.Now)
            {
                case DateTime now when morningShiftTime.InThePeriod(now):
                    return ScheduleShift.Morning;
                case DateTime now when afternoonShiftTime.InThePeriod(now):
                    return ScheduleShift.Afternoon;
                case DateTime now when dinnerShiftTime.InThePeriod(now):
                    return ScheduleShift.Night;
                default:
                    return ScheduleShift.All;
            }
        }
        public List<string> GetValidShift()
        {
            var validShift = new List<string>();
            var shifts = new List<Setting>();
            using (SettingDAL settingDAL = new SettingDAL())
            {
                shifts = settingDAL.GetShiftList();
            }

            Setting.ShiftTime morningShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime afternoonShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime dinnerShiftTime = new Setting.ShiftTime();
            
                morningShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Morning").Value);
                afternoonShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Afternoon").Value);
                dinnerShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Night").Value);
            
            switch (DateTime.Now)
            {
                case DateTime now when morningShiftTime.InThePeriod(now):
                    validShift.Add(DoctorScheduleDAL.ScheduleShiftMap[ScheduleShift.Morning]);
                    break;
                case DateTime now when afternoonShiftTime.InThePeriod(now):
                    validShift.Add(DoctorScheduleDAL.ScheduleShiftMap[ScheduleShift.Afternoon]);
                    break;
                case DateTime now when dinnerShiftTime.InThePeriod(now):
                    validShift.Add(DoctorScheduleDAL.ScheduleShiftMap[ScheduleShift.Night]);
                    break;
            }
            return validShift;
        }
            
    }
}
