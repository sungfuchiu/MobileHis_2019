using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace DAL
{
    public interface ISettingRepo : IRepository<Setting> { }
    public class SettingRepo : EFGenericRepository<Settings>, IRepository
    {

        public GeneralSettings GetGeneralSetting()
        {
            var generalSettings = Context.Set<Setting>()
                .Where(a.ParentSetting.SettingName == SettingType.Default)
                .Dictionary();
            Setting setting = new Setting();
            foreach(var item in GetType().GetProperties())
            {
                PropertyInfo propertyInfo = setting.GetType().GetProperty(item.Name);
                propertyInfo.SetValue(setting, generalSettings[item.Name]);
            }
        }
        public void SetGeneralSetting(GeneralSettings generalSettings)
        {

            foreach (var prop in data.GetType().GetProperties())
            {
                var entity = Context.Set<Setting>().Where(x =>
                    x.ParentSetting.SettingName == SettingType.Default
                    && x.SettingName == settingName)
                    .FirstOrDefault();

                Update(entity);
            }
        }
    }
}
