using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LocalRes;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugRestictionSingleModel
    {
        public string ID { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Comm_Drug")]
        public Guid DrugID { get; set; }
        public string DrugName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Drug_Restrictions")]
        public Guid RestraintID { get; set; }

        public string RestraintName { get; set; }

        [Required(ErrorMessage = "")]
        [Display(ResourceType = typeof(Resource), Name = "Drug_Grade")]
        public string Grade { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Drug_Effect")]
        public string Effect { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Drug_ProcessingMethods")]
        public string ProcessingMethods { get; set; }
    }
}