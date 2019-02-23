using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
   public class SettingViewModel
    {
       public Dictionary<string, string> DefaultSetting { get; set; }
       public Dictionary<string, string> InfoSetting { get; set; }
       public Dictionary<string, string> OtherSetting { get; set; }
       public Dictionary<string, string> MailSetting { get; set; } 
    }
}
