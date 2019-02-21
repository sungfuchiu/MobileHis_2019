using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class PurchaseD
    {
        public PurchaseD() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int PurchaseMID { get; set; }
        [Required]
        public int VendorID { get; set; }
        public Guid DrugGID { get; set; }
       // [MaxLength(18)]
        public decimal Amount { get; set; }
      //  [MaxLength(18)]
        public decimal Price { get; set; }
     //   [MaxLength(18)]
        public decimal PaidAmount { get; set; }
        public DateTime? EstimatedArrivalDate { get; set; }
        public DateTime? RealArrivalDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        public bool Deleted { get; set; }

        #region ForeignKey
        [ForeignKey("DrugGID")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }
        [ForeignKey("PurchaseMID")]
        public virtual PurchaseM PurchaseM { get; set; }
        #endregion

        public virtual ICollection<PosTransactionD> PosTransactionD { get; set; }


    }
}