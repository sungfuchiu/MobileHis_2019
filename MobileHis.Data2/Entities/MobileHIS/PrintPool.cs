using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class PrintPool
    {
        public PrintPool() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(12)]
        public string HospitalNo { get; set; }
        [MaxLength(30)]
        public string Ip { get; set; }        
        public bool Done { get; set; }
        public DateTime? CreateDate { get; set; }        
        [MaxLength(100)]
        public string ModUser { get; set; }

    }
}