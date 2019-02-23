using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MobileHis.Models.Areas.Laboratory.ViewModels
{
    public class OrderLaboratoryView
    {
        public Guid? ID { get; set; }

     
        public int RecordID { get; set; }

        [Required]
        public Guid DrugID { get; set; }
        
        [Required]
        //[MaxLength(16)]
        public string AccessionNumber { get; set; }

        [Required]
        public string LaboratoryCode { get; set; }

        [Required]
        public DateTime LaboratoryDate { get; set; }

        [Required]
        public string LaboratoryTime { get; set; }

        public string LaboratoryStatus { get; set; }

        public bool? _Destroy { get; set; }

        public string LaboratoryName { get; set; }

        public string Error { get; set; }

        public MobileHis.Data.Drug Drug { get; set; }
    }
}