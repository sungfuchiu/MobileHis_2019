using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class MedicalRecord
    {
        public MedicalRecord() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(12)]
        public string PatientID { get; set; }
        [Required]
        public string DeptName { get; set; }
        public int? CallNo { get; set; }
        [NotMapped]
        public string sCallNo
        {
            get
            {
                if (CallNo > 0)
                    return DeptName + "-" + CallNo;
                return "";
            }
        }

        public TypeOfVisit? TypeOfVisit { get; set; }

        public bool AlcoholRelated { get; set; }
        public bool InjuryRelated { get; set; }     


        public bool Admit { get; set; }

        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }

        public bool PullOut { get; set; }
        public bool PullIn { get; set; }
        public DateTime VisitDate { get; set; }

        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100)]
        public string UpdatedBy { get; set; }
        public DateTime? PullOutDateTIme { get; set; }
        public DateTime? PullInDateTime { get; set; }
        public bool IsDeleted { get; set; }

        #region ForeignKey
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }
        public virtual Billing Billing { get; set; }
        #endregion

        #region Icollection
        public virtual ICollection<OpdRegister> OpdRegisters { get; set; }
        #endregion


    }
}