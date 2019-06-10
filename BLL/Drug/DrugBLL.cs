using AutoMapper;
using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.Areas.Drug.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using X.PagedList;

namespace BLL
{
    public class DrugBLL : GuidBLLBase<Drug>
    {
        DrugAppearanceDAL _drugAppearanceDAL;
        DrugCostDAL _drugCostDAL;
        DrugDAL _drugDAL;
        DrugAppearanceBLL _drugAppearanceBLL;
        DrugRestrictionDAL _drugRestrictionDAL;
        CodeFileDAL _codeFileDAL;
        CodeFileBLL _codeFileBLL;
        public DrugBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _drugAppearanceDAL = new DrugAppearanceDAL();
            _drugCostDAL = new DrugCostDAL();
            _drugDAL = new DrugDAL();
            _codeFileDAL = new CodeFileDAL();
            _drugAppearanceBLL = new DrugAppearanceBLL();
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            IDAL = _drugDAL;
        }
        public IPagedList<DrugViewModel> Filter(DrugsFilter filter)
        {
            filter = filter ?? _drugAppearanceBLL.NewFilter();
            int currentPage = filter.page ?? 1;

            _drugDAL.Reads(x => x.DrugStock);
             _drugDAL.TitleContains(filter.DrugTitle);
             _drugDAL.DrugTypeIs(filter.DrugType);
             if(IsDrugHasAppearance(filter))
             {
                 _drugDAL.DrugHasAppearance();
                 _drugDAL.DrugColorContains(filter.DrugColor.Where(a => a.IsSelected).Select(a => a.ID));
                 _drugDAL.DrugMajorTypeContains(filter.DrugMajorType.Where(a => a.IsSelected).Select(a => a.ID));
                 _drugDAL.DrugShapeContains(filter.DrugShape.Where(a => a.IsSelected).Select(a => a.ID));
             }

            return _drugDAL.ReadsResult()
                    .OrderBy(a => a.Title)
                    .ToPagedList(currentPage, Config.PageSize)
                    .Select(a => new DrugViewModel(a));
        }

        public IEnumerable<Drug> Filter(string OrderCode, string Title, Guid? FilterDrugID, string FilterType)
        {
            //IQueryable<Drug> Querydata = GetAllWithNoTracking();
            if (OrderCode.IsNullOrEmpty())
            {
                yield break;
            }
            _drugDAL.Reads();
            _drugDAL.Entity = _drugDAL.Entity
                .Where(a => a.OrderCode.Contains(OrderCode) 
                || a.Title.Contains(Title) 
                && string.IsNullOrEmpty(a.DrugType));
            if(FilterDrugID != null)
            {
                _drugDAL.Entity = _drugDAL.Entity.Where(a => a.GID != FilterDrugID);
                _drugDAL.Entity = _drugDAL.Entity.Where(
                    a => !_drugRestrictionDAL.GetIDList(FilterDrugID.Value).Any(x => x == a.GID));
            }
            foreach(var item in _drugDAL.Entity)
            {
                yield return item;
            }
        }
        private bool IsDrugHasAppearance(DrugsFilter filter)
        {
            return filter.DrugShape.Any(a => a.IsSelected) || 
                filter.DrugColor.Any(a => a.IsSelected) || 
                filter.DrugMajorType.Any(a => a.IsSelected);
        }
        //public Drug GetDrugByID(Guid drugID)
        //{
        //    return IDAL.Read(a => a.GID == drugID);
        //}
        public void CreateOrUpdate(DrugViewModel viewModel)
        {
            bool isNewDrug = viewModel.GID == null;
            Drug drug = isNewDrug
                ? new Drug { GID = Guid.NewGuid() }
                : IDAL.Read(a => a.GID == viewModel.GID);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DrugViewModel, Drug>());
            var mapper = config.CreateMapper();
            mapper.Map(viewModel, drug);

            if(viewModel.IsDefaultType)
            {
                drug.PatientFromType = viewModel.PatientFrom;
            }
            using (var scope = new TransactionScope()) //todo:Unit of work
            {
                try
                {
                    if (isNewDrug)
                        IDAL.Add(drug);
                    _drugDAL.Save();

                    if(viewModel.HasAppearance)
                    {
                        bool isNewAppearance = false;
                        DrugAppearance drugAppearance = _drugAppearanceDAL.Read(a => a.DrugID == drug.GID);

                        if(drugAppearance == null)
                        {
                            drugAppearance = new DrugAppearance(drug.GID);
                            isNewAppearance = true;
                        }

                        drugAppearance.Color = viewModel.Color;
                        drugAppearance.MajorType = viewModel.MajorType;
                        drugAppearance.Shape = viewModel.Shape;

                        if (isNewAppearance)
                            _drugAppearanceDAL.Add(drugAppearance);
                        _drugAppearanceDAL.Save();
                    }

                    bool isNewCost= false;
                    DrugCost drugCost = _drugCostDAL.Read(a => a.DrugID == drug.GID);
                    if (drugCost == null)
                    {
                        drugCost = drugCost ?? new DrugCost(drug.GID);
                        isNewCost = true;
                    }
                    if (viewModel.IsDefaultType)
                    {
                        viewModel.Price = 0;
                        drugCost.InitialFee = viewModel.InitialFee;
                        drugCost.DailyFee = viewModel.DailyFee;
                    }
                    drugCost.Price = viewModel.Price;

                    if (isNewCost)
                        _drugCostDAL.Add(drugCost);
                    else
                        _drugCostDAL.Edit(drugCost);
                    _drugCostDAL.Save();

                    if(viewModel.Photo != null)
                    {
                        var storage = MobileHis.Misc.Storage.GetStorage(StorageScope.Drug);
                        storage.Write(drug.GID, viewModel.Photo);
                    }

                }catch(Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
                scope.Complete();
            }
        }
    }
}
