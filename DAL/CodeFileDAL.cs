using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
