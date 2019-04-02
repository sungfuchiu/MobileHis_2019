using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugStockViewModel
    {
        public DrugStockViewModel() { }

        public int ID { get; set; }
        public Guid DrugID { get; set; }
        public DrugViewModel Drug { get; set; }
        [MaxLength(20)]
        public string Lot { get; set; }
        public decimal CurrentStock { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
    }
}
