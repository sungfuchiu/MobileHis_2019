using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public partial class ICD10
    {
        public ICD10() { }

        [Key]
        [Required]
        [MaxLength(10)]
        public string ICD10Code { get; set; }
        [Required]
        [MaxLength]
        public string StdName { get; set; }
        [Required]
        [MaxLength(8)]
        public string Type { get; set; }


        public virtual ICollection<OpdRecord2ICD10> OpdRecord2ICD10 { get; set; }



    }
}