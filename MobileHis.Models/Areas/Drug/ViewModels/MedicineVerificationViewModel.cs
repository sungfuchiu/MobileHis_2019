using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class MedicineVerificationViewModel
    {
        public List<MobileHis.Data.Drug> Entities { get; set; }
        public int Paging { get; set; }
    }

}
