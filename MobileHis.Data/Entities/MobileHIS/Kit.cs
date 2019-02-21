using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Kit
    {
        public Kit() { }

        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string KitCode { get; set; }
        [MaxLength(100)]
        public string KitDescription { get; set; }
        [MaxLength]
        public string Subjective { get; set; }
        [MaxLength]
        public string Objective { get; set; }
        [MaxLength(10)]
        public string ICD10Code1 { get; set; }
        [MaxLength(10)]
        public string ICD10Code2 { get; set; }
        [MaxLength(10)]
        public string ICD10Code3 { get; set; }
        [MaxLength(10)]
        public string ICD10Code4 { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
        [Required]        
        public int AccountID { get; set; }


        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }


    }
}