using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Composition;
using MobileHis_2019.Service.Extension;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public interface IDrugVendorService : IService<DrugVendor>, IAPIService<DrugVendorModel>
    {

    }
    public class DrugVendorService : GenericModelService<DrugVendor, DrugVendorModel>, IAPIService<DrugVendorModel>, IDrugVendorService, IIDServiceComposition<DrugVendor>
    {
        private ICodeFileService _codeFileService;
        private IMapper _mapper;

        public CompositionIDService<DrugVendor> IDService { get; set; }

        public DrugVendorService(IUnitOfWork inDB, ICodeFileService codeFileService) : base(inDB)
        {
            _codeFileService = codeFileService;
            IDService = new CompositionIDService<DrugVendor>(inDB);
        }
        public void Index(DrugVendorModel model)
        {
            model.EntityPageList = db.Repository<DrugVendor>().ReadAll()
                .Where(a => a.VendorID == model.VendorID && !a.IsDeleted)
                .OrderByDescending(a => a.ID)
                .ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
        }

        public void Create(DrugVendorModel model)
        {
            try
            {
                var existDrugVendor = db.Repository<DrugVendor>().ReadAll()
                    .Where(a => model.DrugGuidList.Any(d => d == a.DrugGID))
                    .ToList();
                existDrugVendor.ForEach(m => {
                    m.IsDeleted = false;
                    m.Creator = 0;
                });
                List<DrugVendor> drugVendors = model.DrugGuidList
                    .Where(b => existDrugVendor.Select(a => a.DrugGID).Any(guid => guid == b))
                    .Select(a => new DrugVendor(drugGuid: a, vendorID: model.ID)).ToList();
                Create(drugVendors);
                Save();
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }


        public void Update(DrugVendorModel model)
        {
            try
            {
                var drugVendor = IDService.Read(model.ID);
                if (drugVendor == null)
                {
                    NotFoundError();
                }
                else
                {
                    ToUpdateEntity(model, drugVendor);
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        protected override void ToUpdateEntity(DrugVendorModel model, DrugVendor entity)
        {
            entity.Price = model.Price;
            entity.Unit = model.Unit;
            entity.PurchaseStockRate = model.PurchaseStockRate;
            entity.StockUsingRate = model.StockUsingRate;
            entity.Creator = 1;
        }

        public void Delete(int ID)
        {
            IDService.Delete(ID);
        }
    }
}
