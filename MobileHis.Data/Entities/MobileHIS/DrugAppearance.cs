using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugAppearance
    {
        public DrugAppearance() { }

        [Key, ForeignKey("Drug")]
       
        //  public Guid GID { get; set; }
        public Guid DrugID { get; set; }
        [MaxLength(255)]
        public string MajorType { get; set; }
        [MaxLength(255)]
        public string Color { get; set; }
        [MaxLength(255)]
        public string Shape { get; set; }

      //  [ForeignKey("GID")]
        public virtual Drug Drug { get; set; }

    }
}