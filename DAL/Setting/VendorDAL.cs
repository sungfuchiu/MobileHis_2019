using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VendorDAL : IDDALBase<Vendor>
    {
        public IEnumerable<Vendor> GetList(string keyword = "")
        {
            Reads();
            var vendor = Entity
                .Where(a => !a.Deleted);
            if (!keyword.IsNullOrEmpty())
            {
                vendor = vendor.Where(x =>
                        x.Code.Contains(keyword)
                        || x.Name.Contains(keyword)
                        || x.ShortName.Contains(keyword)
                    );
            }
            foreach (var item in vendor.OrderBy(a => a.Code))
            {
                yield return item;
            }
        }
    }
}
