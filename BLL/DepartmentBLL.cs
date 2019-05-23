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
using X.PagedList;

namespace BLL
{
    public class DepartmentBLL : IDBLLBase<Dept>, IAPIBLL<DepartmentIndexModel>
    {
        private DepartmentDAL _departmentDAL;
        private SettingBLL _settingBLL;
        private IMapper _mapper;
        public DepartmentBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _departmentDAL = new DepartmentDAL();
            _settingBLL = new SettingBLL(validationDictionary);
            IDAL = new DepartmentDAL();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentIndexModel, Dept>());
            _mapper = mapperConfiguration.CreateMapper();
        }
        public void Index(DepartmentIndexModel model)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Dept, DepartmentIndexModel>());
            var mapper = mapperConfiguration.CreateMapper();
            model.DepartmentPageList = (from a in _departmentDAL.GetList(model.Keyword)
                                       select mapper.Map<DepartmentModel>(a))
                                       .ToPagedList(model.Page, Config.PageSize);
            model.SelectListEvent += _settingBLL.GetDropDownList;
        }

        public void Create(DepartmentIndexModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int ID)
        {
            throw new NotImplementedException();
        }


        public void Update(DepartmentIndexModel model)
        {
            throw new NotImplementedException();
        }
    }
}
