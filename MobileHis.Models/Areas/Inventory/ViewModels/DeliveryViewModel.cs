using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Areas.Inventory.ViewModels
{
    public class DeliveryViewModel
    {
        public class DeliveryItemslist
        {
            public int PurchaseDID { get; set; }
            public Guid DrugGid { get; set; }
            public string ItemName { get; set; }
            public decimal? PurchaseAmount { get; set; }
            public string Status { get; set; }
            public string Lot { get; set; }
            public decimal? PurchasePrice { get; set; }
            public decimal? DeliveryAmountTotal { get; set; }
            public decimal? ReturnAmountTotal { get; set; }

        }

        public class PostDeliveryData
        {
            public int PurchaseDID { get; set; }
            public Guid DrugGid { get; set; }
            public string Lot { get; set; }
            public decimal? Amount { get; set; }
            public decimal? Price { get; set; }
        }
    }


}