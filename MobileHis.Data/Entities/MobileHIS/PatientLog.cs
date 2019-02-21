using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class PatientLog
    {
        public PatientLog() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(50)]
        public string OldPatientID {get; set;}
        [MaxLength(50)]
        public string NewPatientID { get; set; }
        [MaxLength(160)]
        public string OldPatientName { get; set; }
        [MaxLength(160)]
        public string NewPatientName { get; set; }
        [MaxLength(20)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
