using AutoMapper;
using Common;
using MobileHis.Data;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Service.Service
{
    public interface ICodeFileService : IService<CodeFile>, IAPIService<CodeFileViewModel>
    {
        List<SelectListItem> GetDropDownList(
            string itemType,
            string selectedValue = "",
            bool hasEmpty = false,
            bool hasAll = false,
            bool onlyRegistered = false,
            int userID = 0);
    }
    public class CodeFileService : GenericModelService<CodeFile, CodeFileViewModel>, IAPIService<CodeFileViewModel>
    {
        public CodeFileService(IValidationDictionary validationDictionary, IUnitOfWork inDB) : base(inDB)
        {
            InitialiseIValidationDictionary(validationDictionary);
        }
        public List<SelectListItem> GetDropDownList(
            string itemType,
            string selectedValue = "",
            bool hasEmpty = false,
            bool hasAll = false,
            bool onlyRegistered = false,
            int userID = 0)
        {
            var list = new List<System.Web.Mvc.SelectListItem>();
            if (hasEmpty)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = LocalRes.Resource.Comm_Select,
                        Value = ""
                    });
            }
            if (hasAll)
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = "ALL",
                        Value = "0"
                    });
            }
            var datalist = GetSelectList(itemType, selectedValue, onlyRegistered, userID);
            list.AddRange(datalist);
            return list;
        }
        protected IEnumerable<SelectListItem> GetSelectList(
            string itemType = "",
            string selectedValue = "",
            bool onlyRegistered = false,
            int userID = 0)
        {
            return db.Repository<CodeFile>().ReadAll().Where(x =>
                x.ItemType.Equals(itemType, StringComparison.InvariantCultureIgnoreCase)
                && x.CheckFlag != "D")
                .OrderBy(x => x.ItemCode)
                .Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = a.ItemDescription,
                    Selected = string.IsNullOrEmpty(selectedValue) ? false : a.ID.ToString() == selectedValue
                });
        }
        private bool IsDeleted(CodeFile item)
        {
            return item.CheckFlag == "D";
        }
        public void Index(CodeFileViewModel model)
        {
            model.CodeFileSelectListEvent += GetDropDownList;
            var data = db.Repository<CodeFile>().ReadAll()
                .Include(a => a.Parent)
                .Where(x => x.CheckFlag != "D")
                .OrderBy(x => x.ItemType)
                .ThenBy(x => x.ItemDescription)
                .Select(x => x);
            if (!model.ItemType.IsNullOrEmpty())
                data = data.Where(x => x.ItemType.Equals(model.ItemType));
            if (!model.Keyword.IsNullOrEmpty())
                data = data.Where(x => x.ItemDescription.Contains(model.Keyword)
                        || x.Remark.Contains(model.Keyword)
                        || x.ItemCode.Contains(model.Keyword)
                    );
            model.CategoryPageList = data.ToPagedList(model.Page, Config.PageSize);
        }
        
        public void Create(CodeFileViewModel model)
        {
            try
            {
                var codeFile = Read(x => x.ItemType.Equals(model.ItemType) && x.ItemCode.Equals(model.ItemCode));
                if (codeFile != null)
                {
                    if (!IsDeleted(codeFile))
                        ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
                    else
                    {
                        codeFile.ParentCodeFile = model.ParentCodeFile;
                        codeFile.CheckFlag = "";
                        codeFile.ModUser = model.ModUser;
                    }
                }
                else
                {
                    ToUpdateEntity(model, codeFile);
                    Create(codeFile);
                }
                Save();
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void Update(CodeFileViewModel model)
        {
            try
            {
                var codeFile = Read(a => a.ID == model.ID);
                if (codeFile != null)
                {
                    ToUpdateEntity(model, codeFile);
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        public void Delete(int ID)
        {
            try
            {
                var codeFile = Read(a => a.ID == ID);
                if (codeFile != null)
                {
                    codeFile.CheckFlag = "D";
                    Save();
                }
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        protected override void ToUpdateEntity(CodeFileViewModel model, CodeFile entity)
        {
            entity.ParentCodeFile = model.ParentCodeFile;
            entity.ItemDescription = model.ItemDescription;
            entity.Remark = model.Remark;
        }
    }
}
