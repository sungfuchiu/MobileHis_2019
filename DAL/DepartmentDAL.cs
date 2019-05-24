using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;

namespace DAL
{
    public class DepartmentDAL : DALBase<Dept>
    {
        public IEnumerable<DepartmentModel> GetList(string keyword = "")
        {
            Reads(a => a.Category_CodeFile);
            var data =  from a in Entity
                        join code in Entities.CodeFile.AsNoTracking() on a.UnitId equals code.ID
                        orderby a.DepNo
                        select new DepartmentModel
                        {
                            ID = a.ID,
                            Category = a.Category,
                            CategoryName = a.Category_CodeFile.ItemDescription, //db.CodeFile.AsNoTracking().Where(y => y.ItemType == "DP" && y.ID == x.Category).Select(y => y.ItemDescription).FirstOrDefault(),
                            UnitId = a.UnitId,
                            UnitName = code.ItemDescription,
                            DepName = a.DepName,
                            DepNo = a.DepNo,
                            IsRegistered = a.IsRegistered,
                            ModDate = a.ModDate,
                            ModUser = a.ModUser
                        };
            if (!string.IsNullOrEmpty(keyword))
                data = data.Where(x => x.DepName.Contains(keyword)
                        || x.CategoryName.Contains(keyword)
                        || x.DepNo.Contains(keyword)
                    );
            foreach (var item in data)
            {
                yield return item;
            }
        }
    }
}
