using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class PosTransactionM
    {
        public PosTransactionM() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int VendorID { get; set; }
        [Required]
        [MaxLength(20)]
        public string DRNo { get; set; }
        public DateTime? InDate { get; set; }
        [MaxLength(1)]
        public string Flag { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public int Creator { get; set; }

        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<PosTransactionD> PosTransactionD { get; set; }

    }
}