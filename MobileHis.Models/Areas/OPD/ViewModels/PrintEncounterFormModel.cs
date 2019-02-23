using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.OPD.ViewModels
{
   public  class PrintEncounterFormModel
   {
       /// <summary>
       /// opd reg seq
       /// </summary>
       public string CallNo { get; set; }
       /// <summary>
       /// receiption create time
       /// </summary>
       public string Date { get; set; }
       /// <summary>
       /// receiption create time
       /// </summary>
       public string EntityTime { get; set; }
       /// <summary>
       /// medical record pullout create time
       /// </summary>
       public string MrTime { get; set; }
       /// <summary>
       /// opd reg create time
       /// </summary>
       public string TriageTime { get; set; }
       /// <summary>
       /// opd record time
       /// </summary>
       public string DoctorTime { get; set; }
       public string PatientName { get; set; }
       public string HospitalNo { get; set; }
       /// <summary>
       /// date of birthday
       /// </summary>
       public string DOB { get; set; }
       public int Age { get; set; }
       public string Gender { get; set; }
       public string Citizen { get; set; }
       public string Provider { get; set; }
       public string DrCode { get; set; }
       public string Clinic { get; set; }
       public TypeOfVisit VisitType { get; set; }
       public bool Alcohol { get; set; }
       public bool Injury { get; set; }

       public bool Diarrhea { get; set; }
       public bool ILI { get; set; }
       public bool Prolonged_Fever { get; set; }
       public bool AFR { get; set; }
       public bool NoneAll { get; set; }
    }
}
