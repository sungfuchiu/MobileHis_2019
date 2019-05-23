using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;
using MobileHis.Data;
using Common;
using AutoMapper;
using MobileHis.Models.Areas.Sys.ViewModels;
using BLL.Interface;
using X.PagedList;

namespace BLL
{
    public class CodeFileBLL : IDBLLBase<CodeFile>, IAPIBLL<CodeFileViewModel>
    {
        private CodeFileDAL _codeFileDAL;
        private SettingBLL _settingBLL;
        private IMapper _mapper;
        public CodeFileBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileDAL = new CodeFileDAL();
            _settingBLL = new SettingBLL(validationDictionary);
            IDAL = new CodeFileDAL();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<CodeFileViewModel, CodeFile>());
            _mapper = mapperConfiguration.CreateMapper();
        }
        ///// <summary>
        ///// 拿取下拉式選單
        ///// </summary>
        ///// <returns></returns>
        //public List<System.Web.Mvc.SelectListItem> GetDropDownList(string itemType, string selectedValue = "", bool hasEmpty = false)
        //{
        //    var list = new List<System.Web.Mvc.SelectListItem>();
        //    if (hasEmpty)
        //    {
        //        list.Add(new SelectListItem { Text = LocalRes.Resource.Comm_Select, Value = "" });
        //    }
        //    var datalist = _codeFileDAL.GetListByItemType(itemType).Select(a => new SelectListItem
        //    {
        //        Value = a.ID.ToString(),
        //        Text = a.ItemDescription,
        //        Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
        //    });
        //    list.AddRange(datalist);
        //    return list;
        //}
        private bool IsDeleted(CodeFile item)
        {
            return item.CheckFlag == "D";
        }
        protected override IEnumerable<SelectListItem> GetSelectList(string itemType, string selectedValue)
        {
            return _codeFileDAL.GetListByItemType(itemType).Select(a => new SelectListItem
            {
                Value = a.ID.ToString(),
                Text = a.ItemDescription,
                Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
            });
        }


        /// <summary>
        /// Get CodeFile List
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <returns></returns>
        //public List<CodeFile> GetList(string itemType = "", string keyword = "")
        //{
        //    return _codeFileDAL.GetList(itemType, keyword);
        //}

        public void Index(CodeFileViewModel model)
        {
            model.SelectListEvent += _settingBLL.GetDropDownList;
            model.CategoryPageList = _codeFileDAL.GetList(model.ItemType, model.Keyword)
                                    .ToPagedList(model.Page, Config.PageSize);
        }

        /// <summary>
        /// 新增
        /// </summary>      
        /// <returns></returns>
        public void Create(CodeFileViewModel model/*int? parentId, string itemType, string itemCode, string itemDesc, string itemRemark, CustomPrincipal User*/)
        {
            //using (var trans = Entities.Database.BeginTransaction())
            //{
                try
                {
                    var codeFile = Read(x => x.ItemType.Equals(model.ItemType) && x.ItemCode.Equals(model.ItemCode));
                    if (codeFile != null)
                    {
                        if (!IsDeleted(codeFile))
                            ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
                            //ValidationDictionary.AddGeneralError("CodeFile is duplicated.");
                    else
                    {
                            //mapper.Map(model, codeFile);
                            //_obj.ParentCodeFile = parentId;
                            //codeFile.ModUser = User.Name;
                            codeFile.ParentCodeFile = model.ParentCodeFile;
                            codeFile.CheckFlag = "";
                            codeFile.ModDate = System.DateTime.Now;
                            codeFile.ModUser = model.ModUser;
                            Edit(codeFile);
                        }
                    }
                    else
                    {
                        codeFile = _mapper.Map<CodeFile>(model);
                        //var newObj = new CodeFile()
                        //{
                        //    ParentCodeFile = parentId,
                        //    ItemType = itemType,
                        //    ItemCode = itemCode,
                        //    ItemDescription = itemDesc,
                        //    Remark = itemRemark,
                        //    CreateDate = System.DateTime.Now,
                        //    ModDate = System.DateTime.Now,
                        //    ModUser = User.Name
                        //};
                        Add(codeFile);
                    }
                    Save();
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    //return Enums.DbStatus.Error;
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            //}

        }
        /// <summary>
        /// 修改
        /// </summary>      
        /// <returns></returns>
        public void Update(CodeFileViewModel model/*string ID, int? parentId, string itemDesc, string itemRemark, CustomPrincipal User*/)
        {
            //using (var trans = db.Database.BeginTransaction())
            //{
                try
                {
                    //int _id = Convert.ToInt32(ID);
                    //var _obj = GetAll().FirstOrDefault(x => x.ID == _id);
                    var codeFile = Read(a => a.ID == model.ID);
                    if (codeFile != null)
                    {
                        codeFile.ParentCodeFile = model.ParentCodeFile;
                        codeFile.ItemDescription = model.ItemDescription;
                        codeFile.Remark = model.Remark;
                        //_obj.ParentCodeFile = parentId;
                        //_obj.ItemDescription = itemDesc;
                        //_obj.Remark = itemRemark;
                        Edit(codeFile);
                        Save();
                        //trans.Commit();
                    }
                    //return Enums.DbStatus.OK;
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    //return Enums.DbStatus.Error;
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            //}
        }
        /// <summary>
        /// 刪除
        /// </summary>       
        /// <returns></returns>       
        public override void Delete(int ID)
        {
            //using (var trans = db.Database.BeginTransaction())
            //{
                try
                {
                    //int _id = Convert.ToInt32(ID);
                    //var obj = GetAll().FirstOrDefault(x => x.ID == _id);
                    var codeFile = Read(a => a.ID == ID);
                    if (codeFile != null)
                    {
                        codeFile.CheckFlag = "D";
                        Edit(codeFile);
                        Save();
                        //trans.Commit();
                        //return Enums.DbStatus.OK;
                    }
                    //else
                        //return Enums.DbStatus.Error;
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    //return Enums.DbStatus.Error;
                    ValidationDictionary.AddGeneralError(ex.Message);
                }
            //}
        }
    }
}
