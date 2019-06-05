using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class DrugVendorModel : BaseAPIModel<DrugVendor>, IGetCodeFileSelectList
    {

        public event GetCodeFileSelectList CodeFileSelectListEvent;
        public List<SelectListItem> UnitList { get => CodeFileSelectListEvent(itemType:"UT", selectedValue:Unit?.ToString()); }
        public List<Guid> DrugGuidList { get; set; }
        public int ID { get; set; }
        public int VendorID { get; set; }

        public Guid DrugGID { get; set; }

        public decimal Price { get; set; }

        public int? Unit { get; set; }
        public string PurchaseStockRate { get; set; }
        public string StockUsingRate { get; set; }
    }
}
