using System;
using System.Collections.Generic;
using System.Linq;
using MobileHis.Data;
using System.Data.Entity;
using System.Globalization;

namespace DAL
{
    public class SettingEntity
    {

    }
    public class SettingDAL : DALBase<Setting>
    {
        public Setting GetSetting(string settingName, SettingType settingType)
        {
            return GetAll()
                .Include(a => a.ParentSetting)
                .FirstOrDefault(
                    a => a.SettingName == settingName 
                    && a.ParentSetting.SettingName == settingType);
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
            return GetAll()
                .Include(a => a.ParentSetting)
                .Where(a => 
                    a.SettingName.Contains("Partner") 
                    && a.ParentSetting.SettingName == SettingType.Default 
                    && string.IsNullOrEmpty(a.Value))
                .OrderBy(a => a.SettingName)
                .ToList();
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
            var itemType = GetSetting("ItemType", SettingType.category);
            if (itemType != null)
            {
                var itemTypeId = itemType.ID;
                var list = GetAllWithNoTracking()
                    .Where(a => a.ParentId == itemTypeId)
                    .Select(a => a.Value)
                    .ToList();
                return list;
            }
            return new List<string>();
        }

        //public List<string> GetValidShift()
        //{
        //    var validShift = new List<string>();
        //    var shifts = GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();

        //    Setting.ShiftTime morningShiftTime = new Setting.ShiftTime();
        //    Setting.ShiftTime afternoonShiftTime = new Setting.ShiftTime();
        //    Setting.ShiftTime dinnerShiftTime = new Setting.ShiftTime();
        //    try
        //    {
        //        morningShiftTime.SetShiftTimeWithString(
        //            shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Morning").Value);
        //        afternoonShiftTime.SetShiftTimeWithString(
        //            shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Afternoon").Value);
        //        dinnerShiftTime.SetShiftTimeWithString(
        //            shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Night").Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    switch (DateTime.Now)
        //    {
        //        case DateTime now when morningShiftTime.InThePeriod(now):
        //            validShift.Add(DorScheduleDal.ScheduleShiftMap[ScheduleShift.Morning]);
        //        case DateTime now when afternoonShiftTime.InThePeriod(now):
        //            validShift.Add(DorScheduleDal.ScheduleShiftMap[ScheduleShift.Afternoon]);
        //        case DateTime now when dinnerShiftTime.InThePeriod(now):
        //            validShift.Add(DorScheduleDal.ScheduleShiftMap[ScheduleShift.Night]);
        //    }
        //    return validShift;
        //}
        public List<Setting> GetShiftList()
        {
            return GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();
        }
        //public ScheduleShift GetCurrentShift()
        //{
        //    var shifts = GetAllWithNoTracking().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();

        //    Setting.ShiftTime morningShiftTime= new Setting.ShiftTime();
        //    Setting.ShiftTime afternoonShiftTime = new Setting.ShiftTime();
        //    Setting.ShiftTime dinnerShiftTime = new Setting.ShiftTime();

        //    morningShiftTime.SetShiftTimeWithString(
        //        shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Morning").Value);
        //    afternoonShiftTime.SetShiftTimeWithString(
        //        shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Afternoon").Value);
        //    dinnerShiftTime.SetShiftTimeWithString(
        //        shifts.FirstOrDefault(a => a.SettingName == "Opd_Shift_Night").Value);

        //    switch(DateTime.Now)
        //    {
        //        case DateTime now when morningShiftTime.InThePeriod(now):
        //            return ScheduleShift.Morning;
        //        case DateTime now when afternoonShiftTime.InThePeriod(now):
        //            return ScheduleShift.Afternoon;
        //        case DateTime now when dinnerShiftTime.InThePeriod(now):
        //            return ScheduleShift.Night;
        //        default:
        //            return ScheduleShift.All;
        //    }
        //}
        //public bool ValidShift(string shift)
        //{
        //    var shifts = GetValidShift();
        //    return shifts.Contains(shift);
        //}
        public SettingViewModel LoadModel()
        {
            var defaultList = GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.Default)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var infoList = GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.info)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var otherList = GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.other)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var mailList = GetAllWithNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.mail)
                .ToDictionary(o => o.SettingName, o => o.Value);
            return new SettingViewModel
            {
                DefaultSetting = defaultList,
                InfoSetting = infoList,
                OtherSetting = otherList,
                MailSetting = mailList
            };
        }
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
            Setting update = GetAll()
                .Include(a => a.ParentSetting)
                .FirstOrDefault(a => 
                    a.ParentSetting.SettingName == parentName.ToString() 
                    && a.SettingName == settingName);
            update.Value = newValue;
            Edit(update);
        }
    }
}
