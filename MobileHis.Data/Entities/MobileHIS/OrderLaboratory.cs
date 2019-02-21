using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OrderLaboratory
    {
        public OrderLaboratory() { }

        [Key]
        public Guid ID { get; set; }
        [Required]
        public int RecordID { get; set; }
        public Guid DrugID { get; set; }
        [Required]
        [MaxLength(50)]
        public string AccessionNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string LaboratoryCode { get; set; }
        [Required]
        public DateTime LaboratoryDate { get; set; }
        [MaxLength(6)]
        public string LaboratoryTime { get; set; }
        [MaxLength(20)]
        public string LaboratoryStatus { get; set; }
        [MaxLength(1000)]
        public byte?[] LaboratoryResult { get; set; }

        [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("RecordID")]
        public virtual OpdRecord OpdRecord { get; set; }

    }
}