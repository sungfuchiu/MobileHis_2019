using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Inventory.ViewModels
{
    public class PurchaseViewModel
    {
        public class PurchaseItemList
        {
            public int PurchaseID { get; set; }
            public string VendorName { get; set; }
            public string ItemName { get; set; }
            public decimal? Price { get; set; }
            public decimal? Amount { get; set; }
            public DateTime? EstimatedArrivalDate { get; set; }
            public DateTime? UpdatedAt { get; set; }            
        }

        public class PurchaseTransactionlist
        {
            public int VendorID { get; set; }
            public string VendorCode { get; set; }
            public string VendorName { get; set; }
            public int ItemCount { get; set; }           
            
        }
    }
}