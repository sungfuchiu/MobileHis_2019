using System;
using System.Collections.Generic;
using System.IO; using System.Linq;
using System.Web;

namespace MobileHis.Models.ApiSetting
{
    public class API
    {
        private static string DNS = System.Configuration.ConfigurationManager.AppSettings["LabDns"];

        public static Uri ReportPathUri
        {
            get
            {
                return GenerateUri("api/v1/report"); 
            }
        }
        private static Uri GenerateUri(string relativeUri)
        {
            return new Uri(new Uri(DNS), relativeUri);
        }
    }
}