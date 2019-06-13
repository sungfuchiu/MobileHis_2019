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
    public interface IDrugVendorBLL
    {
        void Index(DrugVendorModel model);
        void Create(DrugVendorModel model);
        void Update(DrugVendorModel model);
    }
    public class DrugVendorBLL : IDBLLBase<DrugVendor>, IAPIBLL<DrugVendorModel>
    {
        private CodeFileBLL _codeFileBLL;
        private DrugVendorDAL _drugVendorDAL;
        private IMapper _mapper;
        public DrugVendorBLL(IValidationDictionary validationDictionary, IUnitOfWork inDB) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _drugVendorDAL = new DrugVendorDAL();
            //IDAL = _drugVendorDAL;
            _codeFileBLL = new CodeFileBLL(validationDictionary, inDB);
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<DrugVendorModel, DrugVendor>());
            _mapper = mapperConfiguration.CreateMapper();
        }
        public void Index(DrugVendorModel model)
        {
            model.EntityPageList = _drugVendorDAL.GetList(model.VendorID).ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
        }
        public void Create(DrugVendorModel model)
        {
            try
            {
                _drugVendorDAL.Reads();
                var existDrugVendor = _drugVendorDAL.Entity
                    .Where(a => model.DrugGuidList.Any(d => d == a.DrugGID))
                    .ToList();
                existDrugVendor.ForEach(m => {
                    m.IsDeleted = false;
                    m.Creator = 0;
                });
                List<DrugVendor> drugVendors = model.DrugGuidList
                    .Where(b => existDrugVendor.Select(a=>a.DrugGID).Any(guid => guid==b))
                    .Select(a => new DrugVendor()
                {
                    DrugGID = a,
                    Creator = 0,
                    IsDeleted = false,
                    VendorID = model.ID,
                    Price = 0,
                    PurchaseStockRate = "1/1",
                    StockUsingRate = "1/1"
                }).ToList();
                Add(drugVendors);
                Save();
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        
        public void Update(DrugVendorModel model)
        {
            try
            {
                var drugVendor = Read(model.ID);
                if (drugVendor == null)
                {
                    NotFoundError();
                }
                else
                {
                    //drugVendor = _mapper.Map<DrugVendor>(model);
                    drugVendor.Price = model.Price;
                    drugVendor.Unit = model.Unit;
                    drugVendor.PurchaseStockRate = model.PurchaseStockRate;
                    drugVendor.StockUsingRate = model.StockUsingRate;
                    drugVendor.Creator = 1;
                    Save();
                }
            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
    }
}
