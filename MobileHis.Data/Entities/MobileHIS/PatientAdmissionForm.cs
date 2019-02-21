using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileHis.Data
{
    public class PatientAdmissionForm
    {
        [Key]
        public int Id { get; set; }

        public string PatientID { get; set; }

        public DateTime AdmissionDate { get; set; }
        public int? RoomId { get; set; }
        public int? WardId { get; set; }
        public int? Ward2RoomId { get; set; }
        public int? Bed { get; set; }
        public int? AdmittingPhysican { get; set; }
        public bool? AdmitFrom_ER { get; set; }
        public bool? AdmitFrom_OPD { get; set; }
        public bool? AdmitFrom_RHC { get; set; }
        public bool? AdmitFrom_MCH { get; set; }
        [MaxLength(50)]
        public string DischCashier { get; set; }
        [MaxLength(10)]
        public string NewbornWeight { get; set; }
        [MaxLength(10)]
        public string NewbornWeight_OZ { get; set; }
        [MaxLength(10)]
        public string WeeksOfGestation { get; set; }
        //[MaxLength(20)] #148
        //public string IncomeLevel { get; set; }
        /// <summary>
        /// Dismissed
        /// </summary>
        public bool? Discharge_Dismissed { get; set; }
        /// <summary>
        /// Left against medical advice
        /// </summary>
        public bool? Discharge_LeftAgainst { get; set; }
        /// <summary>
        /// Death Under 24 Hours in hospital
        /// </summary>
        public bool? Discharge_Death24 { get; set; }
        /// <summary>
        /// Death 48 Hours and over in hospital
        /// </summary>
        public bool? Discharge_Death48 { get; set; }
        public DateTime? DischargeDate { get; set; }
        public int? DischargeTotalDay //#153
        {
            get
            {
                if (DischargeDate.HasValue && DischargeDate.Value > AdmissionDate)
                {
                    TimeSpan d = DischargeDate.Value - AdmissionDate;
                    return d.Days;
                }
                return null;
            }
        }
        public bool? AutopsyPerformed { get; set; }
        [MaxLength(20)] //#152
        public string CaseOfDeath_A { get; set; }
        [MaxLength(20)]
        public string CaseOfDeath_B { get; set; }
        [MaxLength(20)]
        public string CaseOfDeath_C { get; set; }

        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }


        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }
        [ForeignKey("Ward2RoomId")]
        public virtual Ward2Room Ward2Room { get; set; }

        public ICollection<PatientFinalDiagnosis> FinalDiagnosis { get; set; }
        public ICollection<PatientOperativeProcedure> OperativeProcedure { get; set; }
    }
}
