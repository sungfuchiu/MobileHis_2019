using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OrderExam
    {
        public OrderExam() { }

        [Key]

        public Guid ID { get; set; }
        [Required]
        public int RecordID { get; set; }

        public Guid DrugID { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccessionNumber { get; set; }
        [MaxLength(50)]
        public string ExamCode { get; set; }
        [MaxLength(100)]
        public string ExamMeaning { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        [MaxLength(6)]
        public string ExamTime { get; set; }
        [MaxLength(20)]
        public string ExamStatus { get; set; }
        [MaxLength]
        public string ExamResult { get; set; }
        public bool? IsCheckin { get; set; }


        [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("RecordID")]
        public virtual OpdRecord OpdRecord { get; set; }
      //  [ForeignKey("ID")]
        public virtual ExamReport ExamReport { get; set; }

    }
}