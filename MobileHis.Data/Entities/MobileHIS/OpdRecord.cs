using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OpdRecord
    {
        public OpdRecord() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? OpdRegisterId { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [MaxLength(12)]
        public string PatientID { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int DeptID { get; set; }

        [MaxLength]
        public string Subjective { get; set; }

        [MaxLength]
        public string Objective { get; set; }

        [MaxLength]
        public string Assessment { get; set; }

        [MaxLength]
        public string Plan { get; set; }
        [MaxLength]
        public string Remark { get; set; }
        public bool? PayStatus { get; set; }
        public bool? MedStatus { get; set; }
        public DateTime? MedCreatedAt { get; set; }
        public DateTime? SubmitedAt { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? TempCreatedAt { get; set; }
        [MaxLength(20)]
        public string LabIssueNo { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        #region ForeignKey
        [ForeignKey("OpdRegisterId")]
        public virtual OpdRegister OpdRegister { get; set; }
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DeptID")]
        public virtual Dept Dept { get; set; }
        [ForeignKey("DoctorID")]
        public virtual Account Doctor { get; set; }

        public virtual Billing Billing { get; set; }

        #endregion

        #region ICollection
        //  public virtual ICollection<OpdRegister> OpdRegister { get; set; }
        public virtual ICollection<OpdRecord2ICD10> OpdRecord2ICD10 { get; set; }
        public virtual ICollection<OrderDrug> OrderDrug { get; set; }
        public virtual ICollection<OrderLaboratory> OrderLaboratory { get; set; }
        public virtual ICollection<OrderExam> OrderExam { get; set; }
        public virtual ICollection<OpdRecordAttachment> OpdRecordAttachment { get; set; }
        public virtual ICollection<OpdRecordHistory> OpdRecordHistory { get; set; }


        #endregion

    }
}