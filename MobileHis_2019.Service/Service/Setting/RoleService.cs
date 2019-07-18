using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileHis_2019.Service.Service
{
    public interface IRoleService
    {
        IList<MobileHis.Models.ViewModel.RoleCheckBox> GetRoles();
        void Create(string roleName);
        void Delete(int roleID);
        List<SelectListItem> GetList();

    }
    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork inDB): base(inDB)
        {

        }
        public IList<MobileHis.Models.ViewModel.RoleCheckBox> GetRoles()
        {
            return ReadAll()
                .Select(a => 
                new MobileHis.Models.ViewModel.RoleCheckBox() {
                    Id = a.ID,
                    Name = a.name,
                    Tags = new { @class = "ace lbl" }
                }).ToList();
        }

        public void Create(string roleName)
        {
            try
            {
                if (ReadAll().Any(a => a.name == roleName))
                {
                    ValidationDictionary.AddGeneralError("Duplicated");
                    return;
                }
                Create(new Role(roleName));
                Save();
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void Delete(int roleId)
        {
            var role = Read(a => a.ID == roleId);
            //db.Role.Where(x => x.ID == role_id).FirstOrDefault();
            if (role != null)
            {
                Delete(role);
                db.Repository<Ap2Role>().Delete(
                    db.Repository<Ap2Role>().ReadAll().Where(a => a.role_id == roleId)
                );
                db.Repository<Account2Role>().Delete(
                    db.Repository<Account2Role>().ReadAll().Where(a => a.Role_id == roleId)
                );
                Save();
            }
        }

        public List<SelectListItem> GetList()
        {
            return ReadAll().Select(a => new SelectListItem
            {
                Text = a.name,
                Value = a.ID.ToString()
            }).ToList();
        }
    }
}
