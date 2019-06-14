using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using AutoMapper;
using X.PagedList;
using Common;
using MobileHis_2019.Service.Interface;
using MobileHis_2019.Repository.Interface;
using System.Linq;

namespace MobileHis_2019.Service.Service
{
    public interface IVendorService : IService<Vendor>, IWebService<VendorModel>
    {
    }
    public class VendorService : GenericService<Vendor>, IWebService<VendorModel>, IVendorService
    {
        ICodeFileService _codeFileService;
        IMapper _modelMapper;
        public VendorService(IUnitOfWork inDB, ICodeFileService codeFileService) : base(inDB)
        {
            _codeFileService = codeFileService;
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<VendorModel, Vendor>());
            _modelMapper = mapperConfiguration.CreateMapper();
        }
        public void Index(VendorModel model)
        {
            var vendor = db.Repository<Vendor>().ReadAll()
                .Where(a => !a.Deleted);
            if (!model.Keyword.IsNullOrEmpty())
            {
                vendor = vendor.Where(x =>
                        x.Code.Contains(model.Keyword)
                        || x.Name.Contains(model.Keyword)
                        || x.ShortName.Contains(model.Keyword)
                    );
            }
            model.EntityPageList = vendor.ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
        }
        public VendorModel Read(int ID)
        {
            var vendor = Read(ID);
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<Vendor, VendorModel>());
            var _entityMapper = mapperConfiguration.CreateMapper();
            VendorModel model = _entityMapper.Map<VendorModel>(vendor);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
            return model;
        }

        public void Create(VendorModel model)
        {
            try
            {
                model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
                var vendor = _modelMapper.Map<Vendor>(model);
                Create(vendor);
                Save();
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void Update(VendorModel model)
        {
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
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
        

        public void Delete(int ID)
        {
            var vendor = db.Repository<Vendor>().Read(a => a.ID == ID);
            Delete(vendor);
        }
    }
}
