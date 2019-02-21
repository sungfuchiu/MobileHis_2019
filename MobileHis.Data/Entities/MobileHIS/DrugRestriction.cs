using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugRestriction
    {
        public DrugRestriction() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public Guid DrugID { get; set; }
       
        //[Key]
        public Guid RestraintID { get; set; }
        [MaxLength(20)]
        public string Grade { get; set; }
        [MaxLength(1000)]
        public string Effect { get; set; }
        [MaxLength(1000)]
        public string ProcessingMethods { get; set; }

        [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }
    }
}