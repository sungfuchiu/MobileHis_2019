using MobileHis.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Vendor : IIDEntity
    {
        public Vendor() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }
        public int? PayType { get; set; }
        [MaxLength(20)]
        public string Contact1 { get; set; }
        [MaxLength(20)]
        public string Contact2 { get; set; }
        [MaxLength(20)]
        public string Phone1 { get; set; }
        [MaxLength(20)]
        public string Phone2 { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Fax { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime ModDate { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        public bool Deleted { get; set; }


        public virtual ICollection<DrugVendor> DrugVendor { get; set; }
        public virtual ICollection<PosTransactionM> PosTransactionM { get; set; }
        public virtual ICollection<PurchaseD> PurchaseD { get; set; }

    }
}