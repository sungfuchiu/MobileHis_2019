using AutoMapper;
using BLL.Interface;
using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using X.PagedList;

namespace BLL
{
    public class DepartmentBLL : IDBLLBase<Dept>, IAPIBLL<DepartmentIndexModel>
    {
        private DepartmentDAL _departmentDAL;
        private CodeFileBLL _codeFileBLL;
        private IMapper _mapper;
        public DepartmentBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _departmentDAL = new DepartmentDAL();
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            IDAL = _departmentDAL;
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentIndexModel, Dept>());
            _mapper = mapperConfiguration.CreateMapper();
        }
        protected override IEnumerable<SelectListItem> GetSelectList(
            string itemType = "",
            string selectedValue = "",
            bool onlyRegistered = false,
            int userID = 0)
        {
            return _departmentDAL.GetSelectList(onlyRegistered, userID).Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.DepName,
                Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
            });
        }
        public void Index(DepartmentIndexModel model)
        {
            model.DepartmentPageList = (from a in _departmentDAL.GetList(model.Keyword)
                                       select a).ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
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
                    department = _mapper.Map<Dept>(model);
                    Add(department);
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
                    department.ModDate = System.DateTime.Now;
                    department.ModUser = "advmeds"; //to do user system
                    Edit(department);
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
    }
}
