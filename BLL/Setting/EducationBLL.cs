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
using System.Web.Mvc;

namespace BLL
{
    public class EducationBLL : IDBLLBase<HealthEdu>, IAPIBLL<EducationModel>
    {

        private EducationDAL _educationDAL;
        private IMapper _mapper;
        public EducationBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _educationDAL = new EducationDAL();
            IDAL = _educationDAL;
            //var mapperConfiguration = new MapperConfiguration(
            //    cfg => cfg.CreateMap<RoomModel, Room>()
            //    .ForMember(a => a.CreateDate, o => o.Ignore())
            //    .ForMember(a => a.RoomNo, o => o.Ignore()));
            //_mapper = mapperConfiguration.CreateMapper();
        }

        public void Create(EducationModel model)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetEducationList(int TypeID)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var item in _educationDAL.GetEducationList(TypeID))
            {
                items.Add(new SelectListItem()
                {
                    Text = item.HealthEdu_Name + "(" + LocalRes.Resource.Guardian_IsUsed + ":" + (item.IsUsed ? "Y" : "N") + ")",
                    Value = item.ID.ToString()
                });
            }
            if (items.Count() != 0)
            {
                items.Insert(0, new SelectListItem() { Text = LocalRes.Resource.Comm_Select, Value = "" });
            }
            return items;
        }

        public void Index(EducationModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(EducationModel model)
        {
            throw new NotImplementedException();
        }
    }
}
