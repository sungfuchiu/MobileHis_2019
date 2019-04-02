using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace DAL
{
    public class CodeFileDAL : DALBase<CodeFile>
    {
        public IEnumerable<CodeFile> GetListByitemType(string itemType)
        {
            return base.GetAllWithNoTracking().Where(x => 
                x.ItemType.Equals(itemType, StringComparison.InvariantCultureIgnoreCase) 
                && x.CheckFlag != "D")
                .OrderBy(x => x.ItemCode);
        }
        public List<T> GetListByIds<T>(List<string> list, Expression<Func<CodeFile, T>> expression)
        {
            Reads();
            ContainsIn(list);
            IQueryable<T> result = Select(expression);
            return ReadsResult<T>(result).ToList();
        }
        private void ContainsIn(List<string> list)
        {
            List<int> intList = new List<int>();
            list.ForEach(a => intList.Add(int.Parse(a)));
            ContainsIn(intList);
        }
        private void ContainsIn(List<int> list)
        {
            Entity = Entity.Where(a => list.Contains(a.ID));
        }
    }
}
