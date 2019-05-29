using AutoMapper;
using BLL.Interface;
using Common;
using DAL;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
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
    public class RoomBLL : IDBLLBase<Room>, IAPIBLL<RoomModel>
    {
        private RoomDAL _roomDAL;
        private CodeFileBLL _codeFileBLL;
        private Dept2RoomDAL _dept2RoomDAL;
        private DepartmentBLL _departmentBLL;
        private IMapper _mapper;
        public RoomBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _roomDAL = new RoomDAL();
            _dept2RoomDAL = new Dept2RoomDAL();
            IDAL = _roomDAL;
            _codeFileBLL = new CodeFileBLL(validationDictionary);
            _departmentBLL = new DepartmentBLL(validationDictionary);
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.CreateMap<RoomModel, Room>()
                .ForMember(a => a.CreateDate, o=>o.Ignore())
                .ForMember(a => a.RoomNo, o => o.Ignore()));
            _mapper = mapperConfiguration.CreateMapper();
        }
        public void Index(RoomModel model)
        {
            model.RoomPageList = (from a in _roomDAL.GetList(model.Keyword)
                                        select a).ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileBLL.GetDropDownList;
            model.DepartmentSelectListEvent += _departmentBLL.GetDropDownList;
        }

        public void Create(RoomModel model)
        {
            using(var trans = new TransactionScope()) {
            try
            {
                var item = Read(a => a.RoomNo.Equals(
                    model.RoomNo, StringComparison.CurrentCultureIgnoreCase));
                if (item != null)
                {
                    DuplicatedError();
                }
                else
                {
                        item =_mapper.Map<Room>(model);
                        item.RoomNo = model.RoomNo;
                        item.CreateDate = model.CreateDate;
                        Add(item);
                        Save();
                        if (!model.AllowDept.IsNullOrEmpty())
                        {
                            _dept2RoomDAL.Insert(model.AllowDept, item.ID);
                            _dept2RoomDAL.Save();
                        }
                        trans.Complete();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
            }
        }

        public void Update(RoomModel model)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var item = Read(model.ID);
                    if (item != null)
                    {
                        item = _mapper.Map(model, item);
                        Save();
                        _dept2RoomDAL.Delete(model.ID);
                        if (!model.AllowDept.IsNullOrEmpty())
                        {
                            _dept2RoomDAL.Insert(model.AllowDept, model.ID);
                        }
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            }
        }
        public JObject ReadItem(int ID)
        {
            var room = Read(ID);
            JObject item = JObject.FromObject(room);
            item.Add(new JProperty("AllowDept", string.Join(",", room.Dept2Room.Select(a => a.Dept_id))));
            item.Add(new JProperty("GuardianCategoryID", room != null ? room.Guardian_ID !=null ? room.HealthEdu.HealthEdu_Type_CodeFile.ToString() : "" : ""));
            return item;
        }
    }
}
