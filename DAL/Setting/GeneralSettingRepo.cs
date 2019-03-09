using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace DAL
{
    public interface ISettingRepo : IRepository<Setting> { }
    public class SettingRepo : EFGenericRepository<Setting>, IRepository<Setting>
    {
        public SettingRepo(DbContext entityContext) :base(entityContext)
        {
            Context = entityContext;
        }

        public DefaultSettings GetGeneralSetting()
        {
            var generalSettings = Context.Set<Setting>()
                .Where(a => a.ParentSetting.SettingName == SettingType.Default)
                .ToDictionary(o => o.SettingName, o => o.Value);
            DefaultSettings setting = new DefaultSettings();
            foreach(var item in GetType().GetProperties())
            {
                PropertyInfo propertyInfo = setting.GetType().GetProperty(item.Name);
                propertyInfo.SetValue(setting, generalSettings[item.Name]);
            }
            return setting;
        }
        public void SetGeneralSetting(DefaultSettings generalSettings)
        {

            //foreach (var prop in data.GetType().GetProperties())
            //{
            //    var entity = Context.Set<Setting>().Where(x =>
            //        x.ParentSetting.SettingName == SettingType.Default
            //        && x.SettingName == settingName)
            //        .FirstOrDefault();

            //    Update(entity);
            //}
        }
    }
}
