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
    public class DepartmentDAL : IDDALBase<Dept>
    {
        private AccountDAL _accountDAL;
        public DepartmentDAL()
        {
            _accountDAL = new AccountDAL();
        }
        private enum _role
        {
            admin = 1,
            triage = 6
        }
        public IEnumerable<Dept> GetSelectList(bool onlyRegistered = false, int userID = 0)
        {
            Reads(a => a.Account);
            Entity = Entity.Where(a => onlyRegistered && a.IsRegistered == "Y");
            //var obj = base.GetAllWithNoTracking().Include(a => a.Account).ToList();
            //if (onlyReg)
            //    obj = obj.Where(x => x.IsRegistered == "Y").ToList();
            if (userID > 0)
            {
                var acc = _accountDAL.Read(a => a.ID == userID, a => a.Account2Role);
                //如果今天是admin or triage 可以看全部
                if (!acc.Account2Role.Any(a => a.Role_id == (int)_role.admin || a.Role_id == (int)_role.triage)) //todo:Change user setting later
                {
                    var deptIds = acc.Account2Dept.Select(a => a.DeptId).ToList();
                    Entity = Entity.Where(a => deptIds.Contains(a.ID));
                }
            }
            foreach(var item in Entity)
            {
                yield return item;
            }
        }
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
