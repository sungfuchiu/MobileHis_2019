using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MobileHis.Data;

namespace DAL
{
    public class DepartmentDAL : DALBase<Dept>
    {
        public IEnumerable<Dept> GetList(string keyword = "")
        {
            Reads(a => a.Category_CodeFile);
            var data =  (from a in Entity
                        join code in Entities.CodeFile.AsNoTracking() on a.UnitId equals code.ID
                        orderby a.DepNo
                        select a
                        ).WhereIf(!string.IsNullOrEmpty(keyword), 
                        x => x.DepName.Contains(keyword)
                        || x.Category_CodeFile.ItemDescription.Contains(keyword)
                        || x.DepNo.Contains(keyword));
            //if (!string.IsNullOrEmpty(keyword))
            //    data = data.Where(x => x.DepName.Contains(keyword)
            //            || x.Category_CodeFile.ItemDescription.Contains(keyword)
            //            || x.DepNo.Contains(keyword)
            //        );
            foreach (var item in data)
            {
                yield return item;
            }
        }
    }
}
