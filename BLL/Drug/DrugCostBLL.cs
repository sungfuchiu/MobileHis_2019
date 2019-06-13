using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DrugCostBLL : BLLBase<DrugCost>
    {
        public DrugCostBLL(IUnitOfWork inDB) : base(inDB)
        {
        }
        public DrugCost GetByDrugID(Guid drugID)
        {
            return Read(a => a.DrugID == drugID);
        }
    }
}
