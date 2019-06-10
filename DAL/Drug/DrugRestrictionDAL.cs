using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DrugRestrictionDAL : DALBase<DrugRestriction>
    {
        public IEnumerable<Guid> GetIDList(Guid FilterID)
        {
            Reads();
            var restraintIDs = Entity.Where(x => x.DrugID == FilterID).Select(x => x.RestraintID);
            var drugIDs = Entity.Where(x => x.RestraintID == FilterID).Select(x => x.DrugID);
            foreach(var IDs in restraintIDs.Concat(drugIDs).Distinct())
            {
                yield return IDs;
            }
            //return restraintIDs.Concat(drugIDs).Distinct();
            //if (FilterType == "D") //what does it mean?
            //{
            //    return Entity.Where(x => x.DrugID == FilterID).Select(x => x.RestraintID);
            //}
            //else
            //{
            //    return Entity.Where(x => x.RestraintID == FilterID).Select(x => x.DrugID);
            //}
        }
    }
}
