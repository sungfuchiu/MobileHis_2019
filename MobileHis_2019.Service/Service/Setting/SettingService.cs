using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.ViewModel;
using AutoMapper;
using Common;
using System.Web.Mvc;
using MobileHis_2019.Repository.Interface;
using System.Data.Entity;
using MobileHis_2019.Service.Interface;

namespace MobileHis_2019.Service.Service
{
    public interface ISettingService : IService<Setting>
    {
        bool DeleteImage(string category, string settingName, string fileName);
        SettingView GetAllSetting();
        ScheduleShift GetCurrentShift();
        DefaultSettings GetDefaultSettings();
        List<SelectListItem> GetDropDownList(string itemType, string selectedValue = "", bool hasEmpty = false, bool hasAll = false, bool onlyRegistered = false, int userID = 0);
        object GetGroupSetting(SettingTypes settingTypes, object settings);
        InfoSettings GetInfoSettings();
        MailSettings GetMailSettings();
        OtherSettings GetOthersSettings();
        List<string> GetValidShift();
        bool SetGeneralSetting(SettingView viewModel);
        void SetGroupSetting(SettingTypes settingTypes, object settings);
        bool SetInfoSetting(SettingView viewModel);
        bool SetMailSetting(SettingView viewModel);
        bool SetOthersSetting(SettingView viewModel);
        bool TestTimeValid(string testTime);
        void Update(string settingName, SettingTypes parentName, string newValue);
    }
    public class SettingService : GenericService<Setting>
    {
        public SettingService(IUnitOfWork inDB) : base(inDB)
        {
        }
        public bool SetGeneralSetting(SettingView viewModel)
        {
            DefaultSettings generalSettings = new DefaultSettings();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SystemSettingView, DefaultSettings>());
            var mapper = config.CreateMapper();
            generalSettings = mapper.Map<DefaultSettings>(viewModel.SystemSettingView);

            if(!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Morning_Start))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Morning_Start, "Wrong Format");
            }
            if (!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Morning_End))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Morning_End, "Wrong Format");
            }
            if (!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Afternoon_Start))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Afternoon_Start, "Wrong Format");
            }
            if (!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Afternoon_End))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Afternoon_End, "Wrong Format");
            }
            if (!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Night_Start))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Night_Start, "Wrong Format");
            }
            if (!TestTimeValid(viewModel.SystemSettingView.Opd_Shift_Night_End))
            {
                ValidationDictionary.AddPropertyError<SettingView>(
                    s => s.SystemSettingView.Opd_Shift_Night_End, "Wrong Format");
            }
            if (viewModel.SystemSettingView.BK_img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.backgroundImg);
                generalSettings.BK_img = s.Write(
                    viewModel.SystemSettingView.BK_img_file.FileName, viewModel.SystemSettingView.BK_img_file);
            }
            if (viewModel.SystemSettingView.Official_Banner_Img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                generalSettings.Official_Banner_Img = s.Write(
                    viewModel.SystemSettingView.Official_Banner_Img_file.FileName, 
                    viewModel.SystemSettingView.Official_Banner_Img_file);
            }
            if (viewModel.SystemSettingView.Official_Logo_Img_file != null)
            {
                var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                generalSettings.Official_Logo_Img = s.Write(
                    viewModel.SystemSettingView.Official_Logo_Img_file.FileName, 
                    viewModel.SystemSettingView.Official_Logo_Img_file);
            }
            if (viewModel.SystemSettingView.PartnerFile != null)
            {

                var settings = db.Repository<Setting>().ReadAll().Include(a => a.ParentSetting);
                var partnerImage = settings.Where(a => a.SettingName.Contains("Partner")
                    && a.ParentSetting.SettingName == SettingTypes.Default.ToString()
                    && string.IsNullOrEmpty(a.Value))
                    .OrderBy(a => a.SettingName).ToList();
                var cnt = 0;
                foreach (var file in viewModel.SystemSettingView.PartnerFile)
                {
                    if (file != null)
                    {
                        var fileName = new System.IO.FileInfo(file.FileName).Name;
                        var s = MobileHis.Misc.Storage.GetStorage(StorageScope.Official);
                        fileName = s.Write(fileName, file);
                        partnerImage[cnt].Value = fileName;
                        //settingDAL.Edit(partnerImage[cnt]);
                        cnt++;

                    }
                }
            }
            if (!ValidationDictionary.IsValid())
                return false;
            SetGroupSetting(SettingTypes.Default, generalSettings);
            Save();
            return true;
        }
        public void SetGroupSetting(SettingTypes settingTypes, object settings)
        {
            foreach (var prop in settings.GetType().GetProperties())
            {
                Update(prop.Name, settingTypes, Convert.ToString(prop.GetValue(settings, null)));
            }
        }
        public void Update(string settingName, SettingTypes parentName, string newValue)
        {
            Setting updatedItem = Read(a =>
                    a.ParentSetting.SettingName == parentName.ToString()
                    && a.SettingName == settingName,
                    a => a.ParentSetting);
            updatedItem.Value = newValue;
        }
        public bool TestTimeValid(string testTime)
        {
            string format = "HH:mm";
            DateTime dateTime;
            if (!DateTime.TryParseExact(
                testTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return false;
            }
            return true;
        }

        public bool SetInfoSetting(SettingView viewModel)
        {
            InfoSettings infoSettings = new InfoSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InfoSettingView, InfoSettings>());
            var mapper = config.CreateMapper();
            infoSettings = mapper.Map<InfoSettings>(viewModel.InfoSettingView);
            if (viewModel.InfoSettingView.EnvironmentFile != null)
            {
                foreach (var file in viewModel.InfoSettingView.EnvironmentFile)
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
            if (!ValidationDictionary.IsValid())
                return false;
            SetGroupSetting(SettingTypes.Info, infoSettings);
            return true;
        }
        public bool SetOthersSetting(SettingView viewModel)
        {
            OtherSettings otherSettings = new OtherSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OthersSettingView, OtherSettings>());
            var mapper = config.CreateMapper();
            otherSettings = mapper.Map<OtherSettings>(viewModel.OthersSettingView);
            if (!ValidationDictionary.IsValid())
                return false;
            SetGroupSetting(SettingTypes.Other, otherSettings);
            return true;
        }
        public bool SetMailSetting(SettingView viewModel)
        {
            MailSettings mailSettings = new MailSettings();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MailSettingView, MailSettings>());
            var mapper = config.CreateMapper();
            mailSettings = mapper.Map<MailSettings>(viewModel.MailSettingView);
            if (!ValidationDictionary.IsValid())
                return false;
            SetGroupSetting(SettingTypes.Mail, mailSettings);
            return true;
        }
        public ScheduleShift GetCurrentShift()
        {
            var shifts = new List<Setting>();
            shifts = db.Repository<Setting>().ReadAll().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();
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
            shifts = db.Repository<Setting>().ReadAll().Where(a => a.SettingName.Contains("Opd_Shift_")).ToList();

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
                    validShift.Add(((int)ScheduleShift.Morning).ToString());
                    break;
                case DateTime now when afternoonShiftTime.InThePeriod(now):
                    validShift.Add(((int)ScheduleShift.Afternoon).ToString());
                    break;
                case DateTime now when dinnerShiftTime.InThePeriod(now):
                    validShift.Add(((int)ScheduleShift.Night).ToString());
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
            infoSettings = GetInfoSettings();
            generalSettings = GetDefaultSettings();
            mailSettings = GetMailSettings();
            otherSettings = GetOthersSettings();
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
            var generalSettings = db.Repository<Setting>().ReadAll()
                .Include(a => a.ParentSetting)
                .Where(a => a.ParentSetting.SettingName == settingTypes.ToString())
                    .ToDictionary(o => o.SettingName, o => o.Value);
            foreach (var prop in settings.GetType().GetProperties())
            {
                prop.SetValue(settings, generalSettings[prop.Name]);
            }
            return settings;
        }


        public bool DeleteImage(string category, string settingName, string fileName)
        {
            try
            {
                Storage storage = Storage.GetStorage(category);
                SettingTypes settingType = SettingTypes.Default;
                if (category == StorageScope.HospitalEnvironment)
                    settingType = SettingTypes.Info;
                
                var setting = Read(a => a.SettingName == settingName
                && a.ParentSetting.SettingName == settingType.ToString(),
                a => a.ParentSetting);
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
                    Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<SelectListItem> GetDropDownList(
            string itemType,
            string selectedValue = "",
            bool hasEmpty = false,
            bool hasAll = false,
            bool onlyRegistered = false,
            int userID = 0)
        {
            var list = new List<System.Web.Mvc.SelectListItem>();
            if (hasEmpty)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = LocalRes.Resource.Comm_Select,
                        Value = ""
                    });
            }
            if (hasAll)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = "ALL",
                        Value = "0"
                    });
            }
            var datalist = GetSelectList(itemType, selectedValue, onlyRegistered, userID);
            list.AddRange(datalist);
            return list;
        }
        protected IEnumerable<SelectListItem> GetSelectList(
            string itemType = "",
            string selectedValue = "",
            bool onlyRegistered = false,
            int userID = 0)
        {
            var itemTypes = Read(a => a.SettingName == "ItemType"
                && a.ParentSetting.SettingName == SettingTypes.Category.ToString(),
                a => a.ParentSetting);
            var setting = (itemTypes != null)
                    ? db.Repository<Setting>().ReadAll().Where(a => a.ParentId == itemTypes.ID)
                        .Select(a => a.Value)
                        .ToList()
                    : new List<string>();
            return setting.Select(item => new SelectListItem
            {
                Value = item,
                Text = LocalRes.Resource.ResourceManager.GetString($"Category_{item}"),
                Selected = string.IsNullOrEmpty(selectedValue) ? false : item == selectedValue
            });
        }

    }
}
