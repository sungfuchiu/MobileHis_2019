//using MobileHis.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.MobileHisModel
{
    public class DrugSampleModel
    {
        //[SchemaMapping("DrugName", IsRequired = true)]
        public string DrugName { get; set; }
        //[SchemaMapping("DrugCode", IsRequired = true)]
        public string DrugCode { get; set; }
        //[SchemaMapping("OrderCode", IsRequired = true)]
        public string OrderCode { get; set; }

    }
}