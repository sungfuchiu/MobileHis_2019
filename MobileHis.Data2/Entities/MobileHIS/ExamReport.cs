using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class ExamReport
    {
        public ExamReport() { }

        [Key, ForeignKey("OrderExam")]
     //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExamID { get; set; }
        public DateTime? CreateAt { get; set; }        
        public int? DoctorID { get; set; }
        public DateTime? UpdateAt { get; set; }
        [MaxLength]
        public string ReportContent { get; set; }

        public virtual OrderExam OrderExam { get; set; }

    }
}