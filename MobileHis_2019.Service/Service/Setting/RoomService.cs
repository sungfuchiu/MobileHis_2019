using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public class RoomService : GenericModelService<Room, RoomModel>, IAPIService<RoomModel>
    {
        ICodeFileService _codeFileService;
        IDepartmentService _departmentService;
        public RoomService(
            IValidationDictionary validationDictionary, 
            IUnitOfWork inDB, 
            ICodeFileService codeFileService,
            IDepartmentService departmentService) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileService = codeFileService;
            _departmentService = departmentService;
        }
        public void Index(RoomModel model)
        {
            model.EntityPageList = (from a in db.Repository<Room>()
                                    .ReadAll()
                                    .OrderBy(a => a.RoomNo)
                                    .Select(a => a)
                                    .WhereIf(!string.IsNullOrEmpty(model.Keyword),
                                    a => a.RoomNo.Contains(model.Keyword)
                                    || a.RoomName.Contains(model.Keyword)) select a)
                                    .ToPagedList(model.Page, Config.PageSize);
            model.CodeFileSelectListEvent += _codeFileService.GetDropDownList;
            model.DepartmentSelectListEvent += _departmentService.GetDropDownList;
        }

        public void Create(RoomModel model)
        {
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
                    //item =_mapper.Map<Room>(model);
                    item = ToCreateEntity(model);
                        item.RoomNo = model.RoomNo;
                        item.CreateDate = model.CreateDate;
                        Create(item);
                        if (!model.AllowDept.IsNullOrEmpty())
                        {
                            CreateByText(model.AllowDept, item.ID);
                        }
                        Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void CreateByText(string allowDept, int roomId)
        {
            foreach (var item in allowDept.Split(','))
            {
                db.Repository<Dept2Room>().Create(new Dept2Room()
                {
                    Dept_id = int.Parse(item),
                    Room_id = roomId
                });

            }
            Save();
        }

        public void Update(RoomModel model)
        {
            try
            {
                var item = Read(a => a.ID == model.ID);
                if (item != null)
                {
                    //item = _mapper.Map(model, item);
                    ToUpdateEntity(model, item);
                    var dept2Room = db.Repository<Dept2Room>().Read(a => a.ID == model.ID);
                    db.Repository<Dept2Room>().Delete(dept2Room);
                    if (!model.AllowDept.IsNullOrEmpty())
                    {
                        CreateByText(model.AllowDept, model.ID);
                    }
                }
                Save();
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public JObject ReadItem(int ID)
        {
            var room = Read(a => a.ID == ID);
            JObject item = JObject.FromObject(room);
            item.Add(new JProperty("AllowDept", string.Join(",", room.Dept2Room.Select(a => a.Dept_id))));
            item.Add(new JProperty("GuardianCategoryID", 
                room != null 
                ? room.Guardian_ID !=null 
                ? room.HealthEdu.HealthEdu_Type_CodeFile.ToString() : "" 
                : ""));
            return item;
        }

        public void Delete(int ID)
        {
            var room = db.Repository<Room>().Read(a => a.ID == ID);
            db.Repository<Room>().Delete(room);
        }
    }
}
