using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MobileHis.Data
{
   public  class PatientOperativeProcedure
   {
       [Key]
       public int Id { get; set; }
       public int AdmissionFormId { get; set; }
       [MaxLength(10)]
       public string OperatopmNo { get; set; }
       [MaxLength(100)]
       public string OperativeProcedure { get; set; }
       public DateTime Date { get; set; }
       public bool Is_PO_Infaceion { get; set; }
       public string CreatedBy { get; set; }
       public DateTime CreatedAt { get; set; }
       public string UpdatedBy { get; set; }
       public DateTime UpdatedAt { get; set; }


       [ForeignKey("AdmissionFormId")]
       public PatientAdmissionForm AdmissionForm { get; set; }
    }
}
