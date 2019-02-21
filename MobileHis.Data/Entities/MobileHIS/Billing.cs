using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Billing
    {
        public Billing() { }

        [Key, ForeignKey("MedicalRecord")]
        public int MedicalRecordID { get; set; }


        [DataType("decimal(8,2)")]
        public decimal total_price { get; set; }

        public bool isPay { get; set; }
        public PatientFrom PatientFrom { get; set; }
        public int? InsuranceId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        #region ForeignKey


        public virtual MedicalRecord MedicalRecord { get; set; }
        [ForeignKey("InsuranceId")]
        public virtual CodeFile Insurance { get; set; }
        #endregion

        #region ICollection
        public virtual ICollection<BillingLog> BillingLog { get; set; }
        public virtual ICollection<BillingItemLog> BillingItems { get; set; }
        #endregion

    }
}