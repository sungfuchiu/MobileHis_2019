using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using MobileHis.Comm;
namespace MobileHis.Models.MobileHisModel
{
    public class PatientSampleModel
    {

        //[SchemaMapping("NationalID", IsRequired = true, MinLength = 10, MaxLength = 20)]
        public string NationalID { get; set; }

        //[SchemaMapping("SurName", IsRequired = true)]
        public string SurName { get; set; }

        //[SchemaMapping("FirstName", IsRequired = true)]
        public string FirstName { get; set; }
        //[SchemaMapping("Gender",Format="M,F")]
        public string Gender { get; set; }
        //[SchemaMapping("Birthday")]
        public DateTime Birthday { get; set; }
        //[SchemaMapping("Tel")]
        public string Tel { get; set; }
        //[SchemaMapping("MobilePhone")]
        public string MobilePhone { get; set; }
    }
}