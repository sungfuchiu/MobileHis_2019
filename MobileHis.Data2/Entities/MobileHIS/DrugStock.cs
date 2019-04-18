using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugStock
    {
        public DrugStock() { }

        [Key]        
        public int ID { get; set; }
        [ForeignKey("Drug")]
        public Guid DrugID { get; set; }
        public virtual Drug Drug { get; set; }
        [MaxLength(20)]
        public string Lot { get; set; }
        public decimal CurrentStock { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
       

    }
}