using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DrugCostBLL : BaseBLL<DrugCost>
    {
        public DrugCost GetByDrugID(Guid drugID)
        {
            return Read(a => a.DrugID == drugID);
        }
    }
}
