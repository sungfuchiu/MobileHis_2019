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
using MobileHis.Models.ViewModel;
using AutoMapper;

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

        public bool SetGeneralSetting(SystemSettingView settings)
        {
            DefaultSettings generalSettings = new DefaultSettings();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SystemSettingView, DefaultSettings>());
            var mapper = config.CreateMapper();
            generalSettings = mapper.Map<DefaultSettings>(settings);

            if (settings.BK_img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);
                generalSettings.BK_img = s.Write(settings.BK_img_file.FileName, settings.BK_img_file);
            }
            if (settings.Official_Banner_Img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                generalSettings.Official_Banner_Img = s.Write(
                    settings.Official_Banner_Img_file.FileName, settings.Official_Banner_Img_file);
            }
            if (settings.Official_Logo_Img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                generalSettings.Official_Logo_Img = s.Write(
                    settings.Official_Logo_Img_file.FileName, settings.Official_Logo_Img_file);
            }

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
            //Update(SettingTypes.Default, settings);
            //for mutli file upload
            if (settings.PartnerFile != null && settings.PartnerFile[0].ContentLength > 0)
            {
                //var files = settings.PartnerFile.GetMultiple("Partner_file");

                using (SettingDAL settingDAL = new SettingDAL())
                {
                    var partnerImage = settingDAL.GetEmptyPartnerImgSetting();
                    var cnt = 0;
                    foreach (var file in settings.PartnerFile)
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
            //if (settings.PartnerFile.Files["Partner_file"] != null && settings.PartnerFile.Files["Partner_file"].ContentLength > 0)
            //    {
            //        var files = settings.PartnerFile.Files.GetMultiple("Partner_file");

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
                return true;
        }

        public void SetInfoSetting(InfoSettingView settings)
        {
            InfoSettings infoSettings = new InfoSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InfoSettingView, InfoSettings>());
            var mapper = config.CreateMapper();
            infoSettings = mapper.Map<InfoSettings>(settings);
            if (settings.EnvironmentFile.Files["Environment_file"] != null 
                && settings.EnvironmentFile.Files["Environment_file"].ContentLength > 0)
            {
                var files = settings.EnvironmentFile.Files.GetMultiple("Environment_file");
                foreach (var file in files)
                {
                    if (file != null)
                    {
                        var fileName = new System.IO.FileInfo(file.FileName).Name;
                        var s = MobileHis.Misc.Storage.GetStorage(StorageScope.HospitalEnvironment);

                        fileName = s.Write(fileName, file);
                        if (!string.IsNullOrEmpty(infoSettings.Hospital_Environment))
                            infoSettings.Hospital_Environment += ";";
                        infoSettings.Hospital_Environment += fileName;

                    }
                }
            }
            using (SettingDAL dal = new SettingDAL())
            {
                dal.SetGroupSetting(SettingTypes.Info, infoSettings);
            }
        }
        public void SetOthersSetting(OthersSettingView settings)
        {
            OtherSettings otherSettings = new OtherSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OthersSettingView, OtherSettings>());
            var mapper = config.CreateMapper();
            otherSettings = mapper.Map<OtherSettings>(settings);
            using (SettingDAL dal = new SettingDAL())
            {
                dal.SetGroupSetting(SettingTypes.Other, settings);
            }
        }
        public void SetMailSetting(MailSettingView settings)
        {
            MailSettings mailSettings = new MailSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MailSettingView, MailSettings>());
            var mapper = config.CreateMapper();
            mailSettings = mapper.Map<MailSettings>(settings);
            using (SettingDAL dal = new SettingDAL())
            {
                dal.SetGroupSetting(SettingTypes.Mail, settings);
            }
        }

        //void Update(SettingTypes type, object data)
        //{
        //    using (SettingDAL settingDAL = new SettingDAL())
        //    {
        //        foreach (var prop in data.GetType().GetProperties())
        //        {
        //            //挑出六個尚未合成的時段設定不要進入資料庫比較(尾巴下底線_是重要依據不可刪除)
        //            if (!prop.Name.Contains("Opd_Shift_Morning_") && !prop.Name.Contains("Opd_Shift_Afternoon_") && !prop.Name.Contains("Opd_Shift_Night_")
        //                //not post files
        //                && prop.PropertyType.Name != "HttpPostedFileBase")
        //            {
        //                if (!prop.Name.Contains("Partner"))
        //                {
        //                    settingDAL.Update(prop.Name, type, Convert.ToString(prop.GetValue(data, null)));
        //                }
        //            }
        //        }
        //    }
        //}
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

        public SettingView GetAllSetting()
        {
            InfoSettings infoSettings = new InfoSettings();
            DefaultSettings generalSettings = new DefaultSettings();
            MailSettings mailSettings = new MailSettings();
            OtherSettings otherSettings = new OtherSettings();
            using (SettingDAL dal = new SettingDAL())
            {
                infoSettings = dal.GetInfoSettings();
                generalSettings = dal.GetDefaultSettings();
                mailSettings = dal.GetMailSettings();
                otherSettings = dal.GetOthersSettings();
            }
            var settingView = new SettingView();

            settingView.InfoSettingView = new InfoSettingView();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InfoSettings, InfoSettingView>());
            var mapper = config.CreateMapper();
            settingView.InfoSettingView = mapper.Map<InfoSettingView>(infoSettings);

            settingView.SystemSettingView = new SystemSettingView();
            config = new MapperConfiguration(cfg => cfg.CreateMap<DefaultSettings, SystemSettingView>());
            mapper = config.CreateMapper();
            settingView.SystemSettingView = mapper.Map<SystemSettingView>(generalSettings);

            settingView.MailSettingView = new MailSettingView();
            config = new MapperConfiguration(cfg => cfg.CreateMap<MailSettings, MailSettingView>());
            mapper = config.CreateMapper();
            settingView.MailSettingView = mapper.Map<MailSettingView>(mailSettings);

            settingView.OthersSettingView = new OthersSettingView();
            config = new MapperConfiguration(cfg => cfg.CreateMap<OtherSettings, OthersSettingView>());
            mapper = config.CreateMapper();
            settingView.OthersSettingView = mapper.Map<OthersSettingView>(otherSettings);
            return settingView;
        }

        public bool DeleteImage(string category, string settingName, string fileName)
        {
            try
            {
                Storage storage = Storage.GetStorage(category);
                SettingTypes settingType = SettingTypes.Default;
                if (category == StorageScope.HospitalEnvironment)
                    settingType = SettingTypes.Info;

                using (SettingDAL dal = new SettingDAL())
                {
                    var setting = dal.GetSetting(settingName, settingType);
                    if (setting != null)
                    {
                        if (category == StorageScope.Official)
                        {
                            fileName = setting.Value;
                            storage.Delete(fileName);
                            setting.Value = "";
                        }
                        else if (category == StorageScope.HospitalEnvironment)
                        {
                            var fileArr = setting.Value.Split(';');
                            var fileList = new List<string>(fileArr);
                            storage.Delete(fileName);
                            var newStrArr = fileList.Where(a => a != fileName).ToArray();
                            if (newStrArr.Length == 0)
                                setting.Value = "";
                            else
                                setting.Value = string.Join(";", newStrArr);
                        }
                        dal.Edit(setting);
                        dal.Save();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
