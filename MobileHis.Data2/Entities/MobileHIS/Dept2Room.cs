using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Dept2Room
    {
        public Dept2Room() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? Dept_id { get; set; }


        public int? Room_id { get; set; }


        [ForeignKey("Dept_id")]
        public virtual Dept Dept { get; set; }
        [ForeignKey("Room_id")]
        public virtual Room Room { get; set; }

    }
}