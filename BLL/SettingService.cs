using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;
using DAL.UnitOfWork;
using System.Data.Entity;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis.Misc;
using System.Web;
using MobileHis.Models.ViewModel;
using AutoMapper;

namespace BLL
{
    public interface ISettingService : IService<Setting> { }
    public class SettingService : GenericService<Setting>, ISettingService
    {
        public SettingService(IUnitOfWork unitOfWork) : base(unitOfWork){ }
        public bool SetGeneralSetting(SystemSettingView settings)
        {
            var entity = db.Repository<Setting>().Read(x => x.ParentSetting.SettingName == SettingType.Default);

            AutoMapper.Mapper.Map(settings, entity);

            db.Repository<Setting>().Update(entity);
            if (settings.BK_img_file != null)
            {
                settings.BK_img = WriteFile(settings.BK_img_file.FileName, settings.BK_img_file); ;
            }
            if (settings.Official_Banner_Img_file != null)
            {
                settings.Official_Banner_Img = WriteFile(
                    settings.Official_Banner_Img_file.FileName, settings.Official_Banner_Img_file); ;
            }
            if (settings.Official_Logo_Img_file != null)
            {
                settings.Official_Logo_Img = WriteFile(
                    settings.Official_Logo_Img_file.FileName, settings.Official_Logo_Img_file); ;
            }

            UpdateAll(SettingTypes.Default, settings);
            
            //for mutli file upload
            //if (settings.PartnerFile.Files["Partner_file"] != null && settings.PartnerFile.Files["Partner_file"].ContentLength > 0)
            //{
            //    var files = settings.PartnerFile.Files.GetMultiple("Partner_file");

            //        var partnerImage = GetEmptyPartnerImgSetting();
            //        var cnt = 0;
            //        foreach (var file in files)
            //        {
            //            if (file != null)
            //            {
            //                var fileName = new System.IO.FileInfo(file.FileName).Name;
            //                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
            //                fileName = s.Write(fileName, file);
            //                partnerImage[cnt].Value = fileName;
            //                db.Repository<Setting>().Update(partnerImage[cnt]);
            //                cnt++;

            //            }
            //        }
            //        db.Save();
            //}
            return true;
        }
        private string WriteFile(string fileName, HttpPostedFileBase file)
        {
            var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);

            fileName = s.Write(fileName, file);

            return fileName;
        }

        public bool SetInfoSetting(InfoSettings settings)
        {
            //if (settings.EnvironmentFile.Files["Environment_file"] != null && settings.EnvironmentFile.Files["Environment_file"].ContentLength > 0)
            //{
            //    var files = settings.EnvironmentFile.Files.GetMultiple("Environment_file");
            //    foreach (var file in files)
            //    {
            //        if (file != null)
            //        {
            //            var fileName = new System.IO.FileInfo(file.FileName).Name;
            //            var s = MobileHis.Misc.Storage.GetStorage(StorageScope.HospitalEnvironment);

            //            fileName = s.Write(fileName, file);
            //            if (!string.IsNullOrEmpty(settings.Hospital_Environment)) settings.Hospital_Environment += ";";
            //            settings.Hospital_Environment += fileName;

            //        }
            //    }
            //}
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
            foreach (var prop in data.GetType().GetProperties())
            {
                //挑出六個尚未合成的時段設定不要進入資料庫比較(尾巴下底線_是重要依據不可刪除)
                if (!prop.Name.Contains("Opd_Shift_Morning_") && !prop.Name.Contains("Opd_Shift_Afternoon_") && !prop.Name.Contains("Opd_Shift_Night_")
                    //not post files
                    && prop.PropertyType.Name != "HttpPostedFileBase")
                {
                    if (!prop.Name.Contains("Partner"))
                    {
                        UpdateData(prop.Name, type, Convert.ToString(prop.GetValue(data, null)));
                    }
                }
            }
        }
        public ScheduleShift GetCurrentShift()
        {
            var shifts = new List<Setting>();
            shifts = GetShiftList();
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

            shifts = GetShiftList();

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
                    validShift.Add(DorSchedule.ScheduleShiftMap[ScheduleShift.Morning]);
                    break;
                case DateTime now when afternoonShiftTime.InThePeriod(now):
                    validShift.Add(DorSchedule.ScheduleShiftMap[ScheduleShift.Afternoon]);
                    break;
                case DateTime now when dinnerShiftTime.InThePeriod(now):
                    validShift.Add(DorSchedule.ScheduleShiftMap[ScheduleShift.Night]);
                    break;
            }
            return validShift;
        }
        public class entities
        {
            public int x { get; set; }
        }

        void UpdateAll(SettingTypes typeName, object data)
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
                            UpdateData(prop.Name, typeName, Convert.ToString(prop.GetValue(data, null)));
                        }
                    }
                }
        }
        public void UpdateData(string settingName, SettingTypes parentName, string newValue)
        {
            var entity = db.Repository<Setting>().Reads()
                .Include(x => x.ParentSetting)
                .FirstOrDefault(x => 
                x.ParentSetting.SettingName == parentName.ToString()
                && x.SettingName == settingName);
            entity.Value = newValue;
            db.Repository<Setting>().Update(entity);
        }
        public SettingViewModel LoadSettingViewModel()
        {
            var defaultList = db.Repository<Setting>().Reads().AsNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.Default)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var infoList = db.Repository<Setting>().Reads().AsNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.info)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var otherList = db.Repository<Setting>().Reads().AsNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == SettingType.other)
                .ToDictionary(o => o.SettingName, o => o.Value);
            var mailList = db.Repository<Setting>().Reads().AsNoTracking()
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
        public List<Setting> GetShiftList()
        {
            return db.Repository<Setting>().Reads()
                .AsNoTracking()
                .Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();
        }

        public List<string> GetCategoryList()
        {
            var itemType = GetSetting("ItemType", SettingTypes.Category);
            if (itemType != null)
            {
                var itemTypeId = itemType.ID;
                var list = db.Repository<Setting>().Reads().AsNoTracking()
                    .Where(a => a.ParentId == itemTypeId)
                    .Select(a => a.Value)
                    .ToList();
                return list;
            }
            return new List<string>();
        }
        public Setting GetSetting(string settingName, SettingTypes settingType)
        {
            return db.Repository<Setting>().Reads()
                .Include(a => a.ParentSetting)
                .FirstOrDefault(
                    a => a.SettingName == settingName
                    && a.ParentSetting.SettingName == settingType.ToString());
        }
        public List<Setting> GetEmptyPartnerImgSetting()
        {
            return db.Repository<Setting>().Reads()
                .Include(a => a.ParentSetting)
                .Where(a =>
                    a.SettingName.Contains("Partner")
                    && a.ParentSetting.SettingName == SettingTypes.Default.ToString()
                    && string.IsNullOrEmpty(a.Value))
                .OrderBy(a => a.SettingName)
                .ToList();
        }
        public List<string> GetPartnerImagePath()
        {
            return db.Repository<Setting>().Reads().AsNoTracking()
                .Include(a => a.ParentSetting)
                .Where(a =>
                    a.SettingName.Contains("Partner")
                    && a.ParentSetting.SettingName == SettingTypes.Default.ToString()
                    && !string.IsNullOrEmpty(a.Value))
               .OrderBy(a => a.SettingName)
               .Select(a => a.Value)
               .ToList();
        }

        public override void ProcessHttpPostFile(object viewModel)
        {
            base.ProcessHttpPostFile(viewModel);

        }
    }
}
