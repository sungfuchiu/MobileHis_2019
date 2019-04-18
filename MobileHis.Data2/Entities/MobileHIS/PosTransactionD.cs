using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class PosTransactionD
    {
        public PosTransactionD() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int PosTransactionMID { get; set; }
        [Required]
        public int PurchaseDID { get; set; }
       // [MaxLength(18)]
        public decimal Amount { get; set; }
       // [MaxLength(18)]
        public decimal Price { get; set; }
        [MaxLength(20)]
        public string Lot { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public int Creator { get; set; }
        public int? AcceptancePosTransactionMID { get; set; }

        [ForeignKey("PosTransactionMID")]
        public virtual PosTransactionM PosTransactionM { get; set; }
        [ForeignKey("PurchaseDID")]
        public virtual PurchaseD PurchaseD { get; set; } 

    }
}