using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Object
{
    public class StatisticsICD
    {
        public int Count { get; set; }
        public string ICD10Code { get; set; }
        public string StdName { get; set; }
    }
    public class StatisticsDrug
    {
        public Guid DrugID { get; set; }
        public string OrderCode { get; set; }
        public int Count { get; set; }
    }
   
}
