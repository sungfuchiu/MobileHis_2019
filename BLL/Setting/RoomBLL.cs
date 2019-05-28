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
                cfg => cfg.CreateMap<RoomModel, Room>().ForMember(a => a.CreateDate, o=>o.Ignore()));
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
                //var _obj = base.GetAllWithNoTracking().Where(x => x.RoomNo.Equals(Room_No, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                //判斷是否重複
                if (item != null)
                {
                    DuplicatedError();
                }
                else
                {
                    //var newObj = new Room()
                    //{
                    //    RoomNo = Room_No,
                    //    RoomName = Room_Name,
                    //    RoomMax = RoomMax,
                    //    CreateDate = System.DateTime.Now,
                    //    ModDate = System.DateTime.Now,
                    //    ModUser = User.Name
                    //};

                    //if (!string.IsNullOrEmpty(GuardianID))//有選擇衛教才加入資料庫
                    //{
                    //    newObj.Guardian_ID = Convert.ToInt32(GuardianID);
                    //}
                        item =_mapper.Map<Room>(model);
                        Add(item);
                        Save();
                        if (!model.AllowDept.IsNullOrEmpty())
                        {
                            _dept2RoomDAL.Insert(model.AllowDept, item.ID);
                            _dept2RoomDAL.Save();
                        }
                        trans.Complete();
                    //if (!string.IsNullOrEmpty(AllowDept))
                    //{
                    //    using (Dept2RoomDal dal = new Dept2RoomDal())
                    //    {
                    //        //dal.OpenTransaction();
                    //        dal.Insert(AllowDept, newObj.ID);
                    //        //foreach (var item in AllowDept.Split(','))
                    //        //{
                    //        //    dal.Add(new Dept2Room() { Dept_id = Convert.ToInt32(item), Room_id = newObj.ID });

                    //        //}
                    //        dal.Save();
                    //        //dal.CommitTransaction();

                    //        //dal.DisposeTransaction();
                    //    }
                    //}
                    ////trans.Commit();
                    ////base.CommitTransaction();
                    //return Enums.DbStatus.OK;
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
                // base.RollbackTransaction();
                // trans.Rollback();
                //return Enums.DbStatus.Error;
            }
            }
        }


        public void Update(RoomModel model)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    //int _id = Convert.ToInt32(key);
                    //var _obj = GetAll().Where(x => x.ID == _id).FirstOrDefault();
                    var item = Read(model.ID);
                    if (item != null)
                    {
                        item = _mapper.Map(model, item);
                        //_obj.RoomName = Room_Name;
                        //_obj.RoomMax = RoomMax;
                        //_obj.Remark = Remark;
                        //_obj.ModDate = System.DateTime.Now;
                        //_obj.ModUser = User.Name;

                        //if (!string.IsNullOrEmpty(GuardianID))//有選擇衛教才加入資料庫
                        //{
                        //    _obj.Guardian_ID = Convert.ToInt32(GuardianID);
                        //}
                        //else
                        //{
                        //    _obj.Guardian_ID = null;
                        //}

                        Save();

                        //更新Dept2Room
                        _dept2RoomDAL.Delete(model.ID);
                        if (model.AllowDept.IsNullOrEmpty())
                        {
                            _dept2RoomDAL.Insert(model.AllowDept, model.ID);
                        }
                        //using (Dept2RoomDal dal = new Dept2RoomDal())
                        //{
                        //    dal.DeleteByRoomID(_id);
                        //    //var _dept2RoomObj = db.Dept2Room.Where(x => x.Room_id == _id);
                        //    //foreach (var item in _dept2RoomObj)
                        //    //    db.Dept2Room.Remove(item);
                        //    if (!string.IsNullOrEmpty(AllowDept))
                        //    {
                        //        dal.Insert(AllowDept, _id);
                        //        //foreach (var item in AllowDept.Split(','))
                        //        //    db.Dept2Room.Add(new Dept2Room() { Dept_id = Convert.ToInt32(item), Room_id = _id });
                        //    }

                        //}

                    }
                    scope.Complete();
                    //return Enums.DbStatus.OK;
                }
                catch (Exception ex)
                {
                    //return Enums.DbStatus.Error;
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            }
        }
    }
}
