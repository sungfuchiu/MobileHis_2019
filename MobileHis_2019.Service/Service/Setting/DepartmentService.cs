using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public interface IDepartmentService
    {
        void Create(DepartmentIndexModel model);
        void Delete(int ID);
        List<SelectListItem> GetDropDownList(string itemType, string selectedValue = "", bool hasEmpty = false, bool hasAll = false, bool onlyRegistered = false, int userID = 0);
        void Index(DepartmentIndexModel model);
        void Update(DepartmentIndexModel model);
    }
    public class DepartmentService : GenericModelService<Dept, DepartmentIndexModel>, IAPIService<DepartmentIndexModel>, IDepartmentService
    {
        ICodeFileService _codeFileService;
        IQueryable<Dept> _depts;
        public DepartmentService(IValidationDictionary validationDictionary, IUnitOfWork inDB, ICodeFileService codeFileService):base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileService = codeFileService;
        }
        private enum _role
        {
            admin = 1,
            triage = 6
        }
        public List<SelectListItem> GetDropDownList(
            string itemType,
            string selectedValue = "",
            bool hasEmpty = false,
            bool hasAll = false,
            bool onlyRegistered = false,
            int userID = 0)
        {
            var list = new List<System.Web.Mvc.SelectListItem>();
            if (hasEmpty)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = LocalRes.Resource.Comm_Select,
                        Value = ""
                    });
            }
            if (hasAll)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = "ALL",
                        Value = "0"
                    });
            }
            var datalist = GetSelectList(itemType, selectedValue, onlyRegistered, userID);
            list.AddRange(datalist);
            return list;
        }
        protected IEnumerable<SelectListItem> GetSelectList(
            string itemType = "",
            string selectedValue = "",
            bool onlyRegistered = false,
            int userID = 0)
        {
            var entity = db.Repository<Dept>().ReadAll().Where(a => onlyRegistered && a.IsRegistered == "Y");
            if (userID > 0)
            {
                var account = db.Repository<Account>().Read(a => a.ID == userID, a => a.Account2Role);
                if (!account.Account2Role.Any(a => a.Role_id == (int)_role.admin || a.Role_id == (int)_role.triage)) //todo:Change user setting later
                {
                    var deptIds = account.Account2Dept.Select(a => a.DeptId).ToList();
                    entity = entity.Where(a => deptIds.Contains(a.ID));
                }
            }
            return entity.Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.DepName,
                Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
            });
        }
        public void Index(DepartmentIndexModel model)
        {
            _depts = _depts.Include(a => a.Category_CodeFile);
            var data = from a in _depts
                       join code in db.Repository<CodeFile>().ReadAll() on a.UnitId equals code.ID
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
            if (!string.IsNullOrEmpty(model.Keyword))
                data = data.Where(x => x.DepName.Contains(model.Keyword)
                        || x.CategoryName.Contains(model.Keyword)
                        || x.DepNo.Contains(model.Keyword)
                    );
            model.DepartmentPageList = data.ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
        }

        public void Create(DepartmentIndexModel model)
        {
            try
            {
                var department = Read(a => a.DepNo.Equals(model.DepNo, StringComparison.CurrentCultureIgnoreCase));
                if (department != null)
                {
                    ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
                }
                else
                {
                    department = ToCreateEntity(model);
                    Create(department);
                    Save();
                }
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void Update(DepartmentIndexModel model)
        {
            try
            {
                var department = Read(a => a.ID == model.ID);
                if (department != null)
                {
                    department.DepName = model.DepName;
                    department.IsRegistered = model.IsRegistered;
                    department.UnitId = model.UnitId;
                    department.ModUser = "advmeds";
                    Save();
                }
                else
                {
                    ValidationDictionary.AddGeneralError(LocalRes.Resource.MSG_Duplidate);
                }
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void Delete(int ID)
        {
            try
            {
                var department = Read(a => a.ID == ID);
                if (department != null)
                {
                    Delete(department);
                }
                else
                {
                    ValidationDictionary.AddGeneralError(LocalRes.Resource.MSG_Duplidate);
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
    }
}
