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

namespace BLL
{
    public class CodeFileBLL : BLLBase<CodeFile>
    {
        private CodeFileDAL _codeFileDAL;
        public CodeFileBLL(IValidationDictionary validationDictionary)
        {
            InitialiseIValidationDictionary(validationDictionary);
            _codeFileDAL = new CodeFileDAL();
            IDAL = new CodeFileDAL();
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
        public List<CodeFile> GetList(string itemType = "", string keyword = "")
        {
            return _codeFileDAL.GetList(itemType, keyword);
        }

        /// <summary>
        /// 新增
        /// </summary>      
        /// <returns></returns>
        public void Create(CodeFileViewModel model, string userName/*int? parentId, string itemType, string itemCode, string itemDesc, string itemRemark, CustomPrincipal User*/)
        {
            //using (var trans = Entities.Database.BeginTransaction())
            //{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CodeFileViewModel, CodeFile>());
            var mapper = config.CreateMapper();
                try
                {
                    var codeFile = Read(x => x.ItemType.Equals(model.ItemType) && x.ItemCode.Equals(model.ItemCode));
                    if (codeFile != null)
                    {
                        if (!IsDeleted(codeFile))
                            ValidationDictionary.AddGeneralError("CodeFile is duplicated.");
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
                        codeFile = mapper.Map<CodeFile>(model);
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
                    ValidationDictionary.AddGeneralError("CodeFile is duplicated.");
                }
            //}

        }
    }
}
