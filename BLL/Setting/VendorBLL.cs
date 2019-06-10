using BLL.Interface;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AutoMapper;
using X.PagedList;
using Common;

namespace BLL
{
    public class VendorBLL : IDBLLBase<Vendor>, IWebBLL<VendorModel>
    {
        VendorDAL _vendorDAL;
        CodeFileBLL _codeFileBLL;
        IMapper _modelMapper;
        IValidationDictionary _validationDictionary;
        public VendorBLL(IValidationDictionary validationDictionary)
        {
            _vendorDAL = new VendorDAL();
            IDAL = _vendorDAL;
            _validationDictionary = validationDictionary;
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<VendorModel, Vendor>());
            _modelMapper = mapperConfiguration.CreateMapper();
        }
        public void Index(VendorModel model)
        {
            model.EntityPageList = _vendorDAL.GetList(model.Keyword).ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
        }
        VendorModel IWebBLL<VendorModel>.Read(int ID)
        {
            var vendor = Read(ID);
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<Vendor, VendorModel>());
            var _entityMapper = mapperConfiguration.CreateMapper();
            VendorModel model = _entityMapper.Map<VendorModel>(vendor);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
            return model;
        }

        public void Create(VendorModel model)
        {
            try
            {
                model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
                var vendor = _modelMapper.Map<Vendor>(model);
                Add(vendor);
                Save();
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void Update(VendorModel model)
        {
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
            var vendor = Read(model.ID);
            try
            {
                if (vendor != null)
                {
                    vendor = _modelMapper.Map(model, vendor);
                    Save();
                }
                else
                {
                    NotFoundError();
                }
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        
    }
}
