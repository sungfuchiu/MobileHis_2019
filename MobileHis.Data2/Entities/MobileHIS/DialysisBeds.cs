using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DialysisBeds
    {
        public DialysisBeds() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "nchar")]
        [MaxLength(20)]
        public string Room { get; set; }
        [Column(TypeName = "nchar")]
        [MaxLength(20)]
        public string BedName { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Enable { get; set; }

    }
}