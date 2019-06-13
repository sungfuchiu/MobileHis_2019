using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis_2019.Repository.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    public class DrugSettingService : GenericService<DrugSetting>
    {
        ICodeFileService _codeFileService;
        public DrugSettingService(IValidationDictionary validationDictionary, IUnitOfWork inDB, ICodeFileService codeFileService) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileService = codeFileService;
        }
        public DrugSettingModelView GetSettingByDrugID(Guid drugID)
        {
            Drug drug = db.Repository<Drug>().Read(a => a.GID == drugID);
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Drug, DrugSettingModelView>().ConstructUsing(a =>
                        new DrugSettingModelView(_codeFileService.GetDropDownList))
                        .ForMember(a => a.DrugID, opt => opt.MapFrom(s => s.GID)));
            var mapper = config.CreateMapper();
            var model = mapper.Map<DrugSettingModelView>(drug);
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<DrugSetting, DrugSettingModelView>()
                .ForMember(a => a.Days, opt => opt.MapFrom(s => s.Days))
                .ForMember(a => a.Dose, opt => opt.MapFrom(s => s.Dose))
                .ForMember(a => a.Route, opt => opt.MapFrom(s => s.Route))
                .ForMember(a => a.Frequency, opt => opt.MapFrom(s => s.Frequency))
                .ForMember(a => a.Quantity, opt => opt.MapFrom(s => s.Quantity)));
            var settingMapper = settingConfig.CreateMapper();
            settingMapper.Map(drug.DrugSetting, model);
            model.Formulation = drug.Formulation.HasValue ? db.Repository<CodeFile>().Read(a => a.ID == drug.Formulation.Value)?.ItemDescription : "";
            return model;
        }
        public void CreateOrUpdate(DrugSettingModelView model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DrugSettingModelView, DrugSetting>());
            var mapper = config.CreateMapper();
            var settingModified = Read(a => a.DrugID == model.DrugID);
            bool isNew = false;
            if (settingModified == null)
            {
                isNew = true;
                settingModified = new DrugSetting();
            }
            mapper.Map(model, settingModified);
            if (isNew)
                db.Repository<DrugSetting>().Create(settingModified);
            else
                db.Repository<DrugSetting>().Update(settingModified);
            Save();
        }

        public JObject FrequencyPairs()
        {
            return new JObject(db.Repository<CodeFile>()
                    .ReadAll().Where(x =>
                    x.ItemType.Equals("FQ", StringComparison.InvariantCultureIgnoreCase)
                    && x.CheckFlag != "D")
                    .OrderBy(x => x.ItemCode)
                    .Select(a => new JProperty(a.ItemDescription, a.Remark.TryFloat()))
                    );
        }
    }
}
