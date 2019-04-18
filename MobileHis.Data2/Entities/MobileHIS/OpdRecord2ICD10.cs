using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OpdRecord2ICD10
    {
        public OpdRecord2ICD10() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int OpdRecordID { get; set; }
        [Required]
        [MaxLength(10)]
        public string ICD10Code { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public DiagnosisTypes DiagnosisType { get; set; }



        #region ForeignKey
        [ForeignKey("OpdRecordID")]
        public virtual OpdRecord OpdRecord { get; set; }
        [ForeignKey("ICD10Code")]
        public virtual ICD10 ICD10 { get; set; }
        #endregion

    }
}