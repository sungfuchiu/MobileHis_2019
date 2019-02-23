using System;
using System.Linq;
using MobileHis.Data;

namespace MobileHis.Models.Areas.OPD.ViewModels
{
    public class OpdRegisterUndoneFilter : MobileHis.Models.PageFilter
    {
        public int DoctorID { get; set; }
                
        public int DepartmentID { get; set; }

        public DateTime? SearchBeginDate { get; set; }
        public DateTime? SearchEndDate { get; set; }

        public string patientID { get; set; }



    }
}
