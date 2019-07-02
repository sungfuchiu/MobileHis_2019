using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    public interface IRoleService
    {
        IList<MobileHis.Models.ViewModel.RoleCheckBox> GetRoles();
    }
    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork inDB): base(inDB)
        {

        }
        public IList<MobileHis.Models.ViewModel.RoleCheckBox> GetRoles()
        {
            return db.Repository<Role>()
                .ReadAll()
                .Select(a => 
                new MobileHis.Models.ViewModel.RoleCheckBox() {
                    Id = a.ID,
                    Name = a.name,
                    Tags = new { @class = "ace lbl" }
                }).ToList();
        }
    }
}
