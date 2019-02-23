using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MobileHis.Models.Areas.Laboratory
{
    public class LabCommFun
    {
     //   private static string DNS = System.Configuration.ConfigurationManager.AppSettings["LabDns"];
        public static byte[] DownloadLabReport(string parturl,string DNS,out string file_name)
        {
            byte[] bytes = null;
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(new Uri(DNS), parturl);
                bytes = wc.DownloadData(url);
                file_name = System.IO.Path.GetFileName(url.LocalPath);
            }
           return bytes;
        }
    }
}