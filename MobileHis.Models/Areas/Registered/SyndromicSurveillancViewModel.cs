using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Registered.ViewModels
{
    public struct SyndromicSurveillancViewModel
    {
        public bool? Diarrhea { get; set; }
        public bool? ILI { get; set; }
        public bool? Prolonged_Fever { get; set; }
        public bool? AFR { get; set; }
        public bool? NoneAll { get; set; }
    }
}
