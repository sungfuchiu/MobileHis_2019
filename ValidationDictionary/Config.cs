using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Config
    {
        /// <summary>
        /// 分頁值
        /// </summary>
        public static int PageSize = 15;
        /// <summary>
        /// 拿取WebConfig AppSetting值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
