
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class OrderDrugView
    {
        
        public Guid? ID { get; set; }

        public Guid DrugID { get; set; }

        public int RecordID { get; set; }

        public string DrugName { get; set; }

        [Required]
        public double Dose { get; set; }

        public string Formulation { get; set; }

        //public int Frequency { get; set; }

        public string Route { get; set; }

        public int Days { get; set; }

        public double Quantity { get; set; }

        public decimal Total { get; set; }
        public decimal? stockAmount { get; set; }
    }
}