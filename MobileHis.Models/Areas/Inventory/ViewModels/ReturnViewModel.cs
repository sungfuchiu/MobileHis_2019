using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Inventory.ViewModels
{
    public class ReturnViewModel
    {
        public class ReturnList
        {
            public int PosTransactionMID { get; set; }
            public string DRNo { get; set; }
            public int VendorID { get; set; }
            public string VendorCode { get; set; }
            public string VendorName { get; set; }                     
        }

        public class ReturnItemslist
        {
            public int PosTransactionDID { get; set; }
            public int PurchaseDID { get; set; }
            public Guid DrugGid { get; set; }
            public string ItemName { get; set; }
            public decimal? PurchaseAmount { get; set; }
            public decimal? PurchasePrice { get; set; }
            public decimal? DeliveryAmountTotal { get; set; }
            public decimal? DeliveryPrice { get; set; }
            public decimal? ReturnAmountTotal { get; set; }

        }

        public class PostReturnData
        {
            public int PosTransactionDID { get; set; }
            public int PurchaseDID { get; set; }
            public Guid DrugGid { get; set; }
            public decimal? Amount { get; set; }
            public decimal? Price { get; set; }
        }
    }
}