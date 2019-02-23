using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.Report
{
  public   struct ReceiptModel
    {
      public string HospitalNo { get; set; }
      public string PatientName { get; set; }
      public string Gender { get; set; }
      public int Age { get; set; }     
      public string Birthday { get; set; }
      public decimal TotalAmount { get; set; }
      public decimal PaidPrice { get; set; }
      public decimal Balance { get; set; }
      public string PaidDate { get; set; }
      public string PaidStatus { get; set; }

    }
}
