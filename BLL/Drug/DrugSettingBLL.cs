using AutoMapper;
using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Models.Areas.Drug.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DrugSettingBLL : BLLBase<DrugSetting>
    {
        DrugDAL _drugDAL;
        DrugSettingDAL _drugSettingDAL;
        CodeFileDAL _codeFileDAL;
        CodeFileBLL _codeFileBLL;
        public DrugSettingBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _drugDAL = new DrugDAL();
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            _codeFileDAL = new CodeFileDAL();
            _drugSettingDAL = new DrugSettingDAL();
            IDAL = _drugSettingDAL;
        }
        public DrugSettingModelView GetSettingByDrugID(Guid drugID)
        {
            Drug drug = _drugDAL.Read(drugID);
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Drug, DrugSettingModelView>().ConstructUsing(a =>
                        new DrugSettingModelView(_codeFileBLL.GetDropDownList))
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
            model.Formulation = drug.Formulation.HasValue ? _codeFileDAL.Read(a => a.ID == drug.Formulation.Value)?.ItemDescription : "";
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
                _drugSettingDAL.Add(settingModified);
            else
                _drugSettingDAL.Edit(settingModified);
            _drugSettingDAL.Save();
        }

        public JObject FrequencyPairs()
        {
            return new JObject(_codeFileDAL.GetListByItemType("FQ").Select(
                        a => new JProperty(a.ItemDescription, a.Remark.TryFloat()))
                    );
        }
    }
}
