using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
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

        public static string Md5Salt(string data, string salting = null)
        {
            if (string.IsNullOrWhiteSpace(salting))
            {
                salting = Config.AppSetting("md5SaltKey") ?? "";
            }
            var salt = System.Text.Encoding.UTF8.GetBytes(salting);
            var odata = System.Text.Encoding.UTF8.GetBytes(data);
            var hmacMD5 = new HMACMD5(salt);
            var saltedHash = hmacMD5.ComputeHash(odata);
            return Convert.ToBase64String(saltedHash);
        }
    }
}
