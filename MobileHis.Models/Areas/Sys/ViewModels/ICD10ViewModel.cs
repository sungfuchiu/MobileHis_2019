using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class ICD10ViewModel
    {
        [Required]
        [MaxLength(10)]
        public string ICD10Code { get; set; }
        [Required]
        [MaxLength]
        public string StdName { get; set; }
        [Required]
        [MaxLength(8)]
        public string Type { get; set; }
    }
}
