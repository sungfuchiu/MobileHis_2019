using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ViewModel
{
    public class DrugsOrderViewKit
    {

        public Guid? ID { get; set; }

        public Guid DrugID { get; set; }

        public string DrugLabel { get; set; }

        public double Dose { get; set; }

        public string Formulation { get; set; }

        public KeyValueOptions Frequency { get; set; }

        public KeyValueOptions Route { get; set; }

        public int Days { get; set; }

        public double Quantity { get; set; }

        public string Remark { get; set; }

        public decimal Total { get; set; }

        public bool? _Destroy { get; set; }

        public string Error { get; set; }

    }

    public class QueryOrderDrug
    {
        public int ID { get; set; }
        public string DrugName { get; set; }
        public Guid? DrugID { get; set; }
        public double? Dose { get; set; }
        public string Formulation { get; set; }
        public KeyValueOptions Frequency { get; set; }
        public KeyValueOptions Route { get; set; }
        public int? Days { get; set; }
        public double? Quantity { get; set; }
    }
}
