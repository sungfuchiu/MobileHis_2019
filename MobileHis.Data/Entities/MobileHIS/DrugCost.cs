using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugCost
    {
        public DrugCost() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GID { get; set; }
        [ForeignKey("Drug")]
        public Guid DrugID { get; set; }
        public virtual Drug Drug { get; set; }
        // [MaxLength(10)]
        public decimal Price { get; set; }
        [MaxLength(2)]
        public string Ver { get; set; }
        public DateTime? CreateAt { get; set; }
        public double? InitialFee { get; set; }
        public double? DailyFee { get; set; }

    }
}