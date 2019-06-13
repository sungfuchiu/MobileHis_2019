using MobileHis.Data;
using System;
using MobileHis_2019.Repository.Interface;

namespace MobileHis_2019.Service.Service
{
    public class DrugCostBLL : GenericService<DrugCost>
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
