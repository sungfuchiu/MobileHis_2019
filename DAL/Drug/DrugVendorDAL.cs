using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DrugVendorDAL : IDDALBase<DrugVendor>
    {

        public  IEnumerable<DrugVendor> GetList(int DrugID)
        {
            Reads();
            var drugVendors = Entity.Where(
                a => a.VendorID == DrugID
                && !a.IsDeleted);
            foreach(var item in drugVendors.OrderByDescending(a => a.ID))
            {
                yield return item;
            }
        }
    }
}
