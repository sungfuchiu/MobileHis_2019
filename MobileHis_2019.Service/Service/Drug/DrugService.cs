using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Misc;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public class DrugService : GenericService<Drug>
    {
        IDrugAppearanceService _drugAppearanceService;
        IQueryable<Drug> _drugs;
        public DrugService(
            IValidationDictionary validationDictionary, 
            IUnitOfWork inDB, 
            IDrugAppearanceService drugAppearanceService) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _drugAppearanceService = drugAppearanceService;
        }
        public IPagedList<DrugViewModel> Filter(DrugsFilter filter)
        {
            filter = filter ?? _drugAppearanceService.NewFilter();

            _drugs = db.Repository<Drug>()
                .ReadAll().Include(a => a.DrugStock)
                .Where(a => a.Title.Contains(filter.DrugTitle));
            DrugTypeIs(filter.DrugType);
             if (IsDrugHasAppearance(filter))
             {
                _drugs = _drugs.Where(a => a.DrugAppearance != null);
                 DrugColorContains(filter.DrugColor.Where(a => a.IsSelected).Select(a => a.ID));
                 DrugMajorTypeContains(filter.DrugMajorType.Where(a => a.IsSelected).Select(a => a.ID));
                 DrugShapeContains(filter.DrugShape.Where(a => a.IsSelected).Select(a => a.ID));
             }
            return _drugs.OrderBy(a => a.Title)
                    .ToPagedList(filter.Page, Config.PageSize)
                    .Select(a => new DrugViewModel(a));
        }
        private void DrugTypeIs(string drugType)
        {
            if (drugType.IsNullOrEmpty())
            {
                _drugs = _drugs.Where(a => string.IsNullOrEmpty(a.DrugType));
            }
            else
            {
                _drugs = _drugs.Where(a => a.DrugType == drugType);
            }
        }
        private bool IsDrugHasAppearance(DrugsFilter filter)
        {
            return filter.DrugShape.Any(a => a.IsSelected) ||
                filter.DrugColor.Any(a => a.IsSelected) ||
                filter.DrugMajorType.Any(a => a.IsSelected);
        }
        private void DrugColorContains(IEnumerable<string> drugColors)
        {
            _drugs = _drugs.Where(
                a => a.DrugAppearance.Color != null
                && drugColors.Contains(a.DrugAppearance.Color));
        }
        private void DrugMajorTypeContains(IEnumerable<string> drugMajorTypes)
        {
            _drugs = _drugs.Where(
                a => a.DrugAppearance.MajorType != null
                && drugMajorTypes.Contains(a.DrugAppearance.MajorType));
        }
        private void DrugShapeContains(IEnumerable<string> drugShapes)
        {
            _drugs = _drugs.Where(
                a => a.DrugAppearance.Shape != null
                && drugShapes.Contains(a.DrugAppearance.Shape));
        }

        public IEnumerable<Drug> Filter(string OrderCode, string Title, Guid? FilterDrugID, string FilterType)
        {
            if (OrderCode.IsNullOrEmpty())
            {
                yield break;
            }
            _drugs = db.Repository<Drug>().ReadAll();
            _drugs = _drugs.Where(a => 
                a.OrderCode.Contains(OrderCode) 
                || a.Title.Contains(Title) 
                && string.IsNullOrEmpty(a.DrugType));
            if(FilterDrugID != null)
            {
                _drugs = _drugs.Where(a => a.GID != FilterDrugID);
                _drugs = _drugs.Where(
                    a => !GetIDList(FilterDrugID.Value).Any(x => x == a.GID));
            }
            foreach (var item in _drugs)
            {
                yield return item;
            }
        }
        private IEnumerable<Guid> GetIDList(Guid FilterID)
        {
            var _drugRestriction = db.Repository<DrugRestriction>().ReadAll();
            var restraintIDs = _drugRestriction.Where(x => x.DrugID == FilterID).Select(x => x.RestraintID);
            var drugIDs = _drugRestriction.Where(x => x.RestraintID == FilterID).Select(x => x.DrugID);
            foreach (var IDs in restraintIDs.Concat(drugIDs).Distinct())
            {
                yield return IDs;
            }
        }
        public void CreateOrUpdate(DrugViewModel viewModel)
        {
            bool isNewDrug = viewModel.GID == null;
            Drug drug = isNewDrug
                ? new Drug { GID = Guid.NewGuid() }
                : db.Repository<Drug>().Read(a => a.GID == viewModel.GID);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DrugViewModel, Drug>());
            var mapper = config.CreateMapper();
            mapper.Map(viewModel, drug);

            if(viewModel.IsDefaultType)
            {
                drug.PatientFromType = viewModel.PatientFrom;
            }
            try
            {
                if (isNewDrug)
                    db.Repository<Drug>().Create(drug);

                if(viewModel.HasAppearance)
                {
                    bool isNewAppearance = false;
                    DrugAppearance drugAppearance = db.Repository<DrugAppearance>().Read(a => a.DrugID == drug.GID);

                    if(drugAppearance == null)
                    {
                        drugAppearance = new DrugAppearance(drug.GID);
                        isNewAppearance = true;
                    }

                    drugAppearance.Color = viewModel.Color;
                    drugAppearance.MajorType = viewModel.MajorType;
                    drugAppearance.Shape = viewModel.Shape;

                    if (isNewAppearance)
                        db.Repository<DrugAppearance>().Create(drugAppearance);
                }

                bool isNewCost= false;
                DrugCost drugCost = db.Repository<DrugCost>().Read(a => a.DrugID == drug.GID);
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
                    db.Repository<DrugCost>().Create(drugCost);
                else
                    db.Repository<DrugCost>().Update(drugCost);

                if(viewModel.Photo != null)
                {
                    var storage = MobileHis.Misc.Storage.GetStorage(StorageScope.Drug);
                    storage.Write(drug.GID, viewModel.Photo);
                }
                db.Save();

            }catch(Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
    }
}
