using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public partial class OpdRegister
    {
        public OpdRegister() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(12)]
        public string BookingNo { get; set; }
        [MaxLength(12)]
        public string PatinetID { get; set; }
        public DateTime? OpdDate { get; set; }
        public int? Deptid { get; set; }
        public int? RoomID { get; set; }
        [MaxLength(2)]
        public string ShiftNo { get; set; }
        [MaxLength(2)]
        public string RegType { get; set; }
        [MaxLength(1)]
        public string RecStatus { get; set; }
        [MaxLength(1)]
        public string OpdStatus { get; set; }
        [MaxLength(12)]
        public string AdmissionNo { get; set; }
        [MaxLength(12)]
        public string ReferalNo { get; set; }
        public int? Seq { get; set; }
        [MaxLength]
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
        [Required]
        public int DorScheduleId { get; set; }
        public int? MedicalRecordId { get; set; }
       // public int? OpdRecordID { get; set; }
        public bool IsDeleted { get; set; }

        #region ForeignKey
        [ForeignKey("PatinetID")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("Deptid")]
        public virtual Dept Dept { get; set; }
        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }
        [ForeignKey("DorScheduleId")]
        public virtual DorSchedule DorSchedule { get; set; }

        [ForeignKey("MedicalRecordId")]
        public virtual MedicalRecord MedicalRecord { get; set; }
        #endregion
        /// <summary>
        /// please use first or default
        /// </summary>
        public virtual ICollection<OpdRecord> OpdRecord { get; set; }
    }
}