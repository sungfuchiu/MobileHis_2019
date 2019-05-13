using DAL;
using MobileHis.Data;
using MobileHis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Models.Areas.Sys.ViewModels;
using AutoMapper;
using Common;

namespace BLL
{
    public class ICD10BLL : BLLBase<ICD10>
    {
        public ICD10BLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
        }

        public List<JsonSearchModel> Search(string search, string exclude, int recordCnt)
        {
            var arrExclude = exclude.Split(';').Where(a => !string.IsNullOrEmpty(a)).ToList();
            using (DALBase<ICD10> dal = new DALBase<ICD10>())
            {
                return dal.GetAllWithNoTracking().Where(i =>
                    (i.ICD10Code.Contains(search) || i.StdName.Contains(search))
                    && !arrExclude.Contains(i.ICD10Code))
                    .OrderBy(i => i.ICD10Code.Length)
                    .ThenBy(i => i.ICD10Code)
                    .Take(recordCnt)
                    .Select(i => new JsonSearchModel
                    {
                        id = i.ICD10Code,
                        text = "[" + i.ICD10Code + "] " + i.StdName
                    }).ToList();
            }
        }
        public List<ICD10ViewModel> GetList(string keyword, string type)
        {
            ICD10ViewModel iCD10View = new ICD10ViewModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ICD10, ICD10ViewModel>());
            var mapper = config.CreateMapper();
            using (DALBase<ICD10> DAL = new DALBase<ICD10>())
            {
                var result = DAL.GetAllWithNoTracking();
                if (!string.IsNullOrEmpty(keyword))
                    result = result.Where(a => a.ICD10Code == keyword || a.StdName.Contains(keyword));
                if (!string.IsNullOrEmpty(type))
                    result = result.Where(a => a.Type == type);

                var icd10 = mapper.Map<List<ICD10>, List<ICD10ViewModel>>(result.ToList());
                return icd10;
            }
        }
        public ICD10 GetByCode(string code)
        {
            using (DALBase<ICD10> DAL = new DALBase<ICD10>())
                return DAL.Read(o => o.ICD10Code == code);
        }

        public bool Add(string code, string name, string type)
        {
            try
            {
                using (DALBase<ICD10> DAL = new DALBase<ICD10>())
                {
                    if (DAL.GetAllWithNoTracking().Any(a => a.ICD10Code == code))
                    {
                        ValidationDictionary.AddGeneralError("Duplicated");
                        return false;
                    }
                    DAL.Add(new ICD10
                    {
                        ICD10Code = code,
                        StdName = name,
                        Type = type
                    });
                    DAL.Save();
                    return true;

                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddPropertyError<ICD10ViewModel>(
                    i => i.ICD10Code, ex.Message);
                return false;
            }
        }
        public bool Edit(string code, string name, string type)
        {
            try
            {
                using (DALBase<ICD10> DAL = new DALBase<ICD10>())
                {
                    var update = DAL.Read(o => o.ICD10Code == code);
                    update.StdName = name;
                    update.Type = type;
                    DAL.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddPropertyError<ICD10ViewModel>(
                    i => i.ICD10Code, ex.Message);
                return false;
            }
        }
    }
}
