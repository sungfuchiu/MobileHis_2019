using MobileHis.Data;
using System;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;

namespace MobileHis_2019.Service.Service
{
    public interface IDrugCostService : IService<DrugCost>
    {
        DrugCost GetByDrugID(Guid drugID);
    }
    public class DrugCostService : GenericService<DrugCost>, IDrugCostService
    {
        public DrugCostService(IUnitOfWork inDB) : base(inDB)
        {
        }
        public DrugCost GetByDrugID(Guid drugID)
        {
            return Read(a => a.DrugID == drugID);
        }
    }
}
