using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileHis.Data
{
    public class PatientFinalDiagnosis
    {
        [Key]
        public int Id { get; set; }
        public int AdmissionFormId { get; set; }

        
       // public string DiagnosisNumber { get; set; } //#150
        [MaxLength(10)]
        public string Diagnosis { get; set; }
        [MaxLength(10)]
        public string ConditionOnDischarge { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("AdmissionFormId")]
        public PatientAdmissionForm AdmissionForm { get; set; }

    }
}
