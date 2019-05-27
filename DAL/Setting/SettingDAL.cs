using System;
using System.Collections.Generic;
using System.Linq;
using MobileHis.Data;
using System.Data.Entity;
using System.Globalization;
using Common;

namespace DAL
{
    public class SettingDAL : DALBase<Setting>
    {
        public Setting GetSetting(string settingName, SettingTypes settingType)
        {
            return Read(a => a.SettingName == settingName
                && a.ParentSetting.SettingName == settingType.ToString(),
                a => a.ParentSetting);
        }
        //public GeneralSettings GetGeneralSettings()
        //{
        //    var generalSettings = GetAll()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == SettingTypes.Default.ToString())
        //            .ToDictionary(o => o.SettingName, o => o.Value);
        //    GeneralSettings settings = new GeneralSettings();
        //    foreach (var prop in settings.GetType().GetProperties())
        //    {
        //         prop.SetValue(settings, generalSettings[prop.Name]);
        //    }
        //    return settings;
        //}
        public DefaultSettings GetDefaultSettings()
        {
            return (DefaultSettings)GetGroupSetting(SettingTypes.Default, new DefaultSettings());
        }
        public InfoSettings GetInfoSettings()
        {
            return (InfoSettings)GetGroupSetting(SettingTypes.Info, new InfoSettings());
        }
        public MailSettings GetMailSettings()
        {
            return (MailSettings)GetGroupSetting(SettingTypes.Mail, new MailSettings());
        }
        public OtherSettings GetOthersSettings()
        {
            return (OtherSettings)GetGroupSetting(SettingTypes.Other, new OtherSettings());
        }
        public object GetGroupSetting(SettingTypes settingTypes, object settings)
        {
            var generalSettings = GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == settingTypes.ToString())
                    .ToDictionary(o => o.SettingName, o => o.Value);
            foreach (var prop in settings.GetType().GetProperties())
            {
                prop.SetValue(settings, generalSettings[prop.Name]);
            }
            return settings;
        }
        public void SetGroupSetting(SettingTypes settingTypes, object settings)
        {
            foreach (var prop in settings.GetType().GetProperties())
            {
                Update(prop.Name, settingTypes, Convert.ToString(prop.GetValue(settings, null)));
            }
            Save();
        }
        //public List<Setting> GetSetting(string settingType)
        //{
        //    return GetAllWithNoTracking()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == settingType)
        //        .ToList();
        //}
        public List<Setting> GetEmptyPartnerImgSetting()
        {
            Reads(a => a.ParentSetting);
            Entity = Entity.Where(a => a.SettingName.Contains("Partner")
                && a.ParentSetting.SettingName == SettingTypes.Default.ToString()
                && string.IsNullOrEmpty(a.Value))
                .OrderBy(a => a.SettingName);
            return Entity.ToList();
        }
        public List<string> GetPartnerImagePath()
        {
            return GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => 
                    a.SettingName.Contains("Partner") 
                    && a.ParentSetting.SettingName == SettingType.Default 
                    && !string.IsNullOrEmpty(a.Value))
               .OrderBy(a => a.SettingName)
               .Select(a => a.Value)
               .ToList();
        }
        public List<string> GetCategoryList()
        {
            Reads();
            var itemType = GetSetting("ItemType", SettingTypes.Category);
            return (itemType != null) 
                    ? Entity.Where(a => a.ParentId == itemType.ID)
                        .Select(a => a.Value)
                        .ToList()
                    : new List<string>();
            //if (itemType != null)
            //{
            //    var list = GetAllWithNoTracking()
            //        .Where(a => a.ParentId == itemType.ID)
            //        .Select(a => a.Value)
            //        .ToList();
            //    return list;
            //}
            //return new List<string>();
        }

        public List<string> GetValidShift()
        {
            var validShift = new List<string>();
            var shifts = GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();

            Setting.ShiftTime morningShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime afternoonShiftTime = new Setting.ShiftTime();
            Setting.ShiftTime dinnerShiftTime = new Setting.ShiftTime();
            try
            {
                morningShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Morning").Value);
                afternoonShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Afternoon").Value);
                dinnerShiftTime.SetShiftTimeWithString(
                    shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Night").Value);
            }
            catch (Exception ex)
            {
                return null;
            }
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
        public List<Setting> GetShiftList()
        {
            return GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();
        }
        public ScheduleShift GetCurrentShift()
        {
            var shifts = GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();

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
        //public bool ValidShift(string shift)
        //{
        //    var shifts = GetValidShift();
        //    return shifts.Contains(shift);
        //}
        //public SettingViewModel LoadModel()
        //{
        //    var defaultList = GetAllWithNoTracking()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == SettingType.Default)
        //        .ToDictionary(o => o.SettingName, o => o.Value);
        //    var infoList = GetAllWithNoTracking()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == SettingType.info)
        //        .ToDictionary(o => o.SettingName, o => o.Value);
        //    var otherList = GetAllWithNoTracking()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == SettingType.other)
        //        .ToDictionary(o => o.SettingName, o => o.Value);
        //    var mailList = GetAllWithNoTracking()
        //        .Include(a => a.ParentSetting)
        //        .Where(a => a.ParentSetting.SettingName == SettingType.mail)
        //        .ToDictionary(o => o.SettingName, o => o.Value);
        //    return new SettingViewModel
        //    {
        //        DefaultSetting = defaultList,
        //        InfoSetting = infoList,
        //        OtherSetting = otherList,
        //        MailSetting = mailList
        //    };
        //}
        //Dictionary<string, string> ListToDict(List<Setting> list)
        //{
        //    var result = new Dictionary<string, string>();
        //    foreach (Setting s in list)
        //    {
        //        result.Add(s.SettingName, s.Value);
        //    }
        //    return result;
        //}

        public void Update(string settingName, SettingTypes parentName, string newValue)
        {
            Setting updatedItem = Read(a =>
                    a.ParentSetting.SettingName == parentName.ToString()
                    && a.SettingName == settingName,
                    a => a.ParentSetting);
            updatedItem.Value = newValue;
            Edit(updatedItem);
        }
    }
}
