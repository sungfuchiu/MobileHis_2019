using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OrderDrug
    {
        public OrderDrug() { }

        [Key]
     //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        public int RecordID { get; set; }
        [Required]
        public double Dose { get; set; }
        [Required]
        public int Frequency { get; set; }
        [Required]
        public int Route { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal OverridePrice { get; set; }
        [MaxLength]
        public string Remark { get; set; }        
        public Guid DrugID { get; set; }


        [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("RecordID")]
        public virtual OpdRecord OpdRecord { get; set; }

    }
}