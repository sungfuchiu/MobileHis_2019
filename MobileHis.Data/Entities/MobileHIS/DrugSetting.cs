using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugSetting
    {
        public DrugSetting()
        {
            //this.Dose = 0;
            //this.Days = 0;
            //this.Quantity = 0;

        }

        [Key, ForeignKey("Drug")]
     
      // public Guid ID { get; set; }
        [Required]
        public Guid DrugID { get; set; }
        public double Dose { get; set; }
        [MaxLength(8)]
        public string Frequency { get; set; }
        [MaxLength(8)]
        public string Route { get; set; }
        public int? Days { get; set; }
        public double Quantity { get; set; }

      //  [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }

    }
}