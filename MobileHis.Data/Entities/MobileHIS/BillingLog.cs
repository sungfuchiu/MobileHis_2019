using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class BillingLog
    {
        public BillingLog() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }      
        [Required]
         public int MedicalRecordID { get; set; }

        [DataType("decimal(8,2)")]
        public decimal amt_price { get; set; }

        [DataType("decimal(8,2)")]
        public decimal pay_price { get; set; }
        [MaxLength(100)]
        public string remark { get; set; }
      
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        #region ForeignKey
        [ForeignKey("MedicalRecordID")]
        public virtual Billing Billing { get; set; }       
        #endregion


    }
}