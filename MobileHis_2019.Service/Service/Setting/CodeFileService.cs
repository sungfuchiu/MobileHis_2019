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
        List<SelectListItem> GetCategoryList(
            string selectedValue = "",
            bool hasEmpty = false);
    }
    public class CodeFileService : GenericModelService<CodeFile, CodeFileViewModel>, IAPIService<CodeFileViewModel>, ICodeFileService
    {
        public CodeFileService(IUnitOfWork inDB) : base(inDB)
        {
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
        public List<SelectListItem> GetCategoryList(
            string selectedValue = "",
            bool hasEmpty = false)
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
            //var datalist = GetCategory(selectedValue);
            foreach(var item in GetCategory())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Value,
                    Text = @LocalRes.Resource.ResourceManager.GetString("Category_" + item.Value.ToString()),
                    Selected = string.IsNullOrEmpty(selectedValue) ? false : item.Value.ToString() == selectedValue
                });
            }
            //list.AddRange(datalist);
            return list;
        }
        private bool IsDeleted(CodeFile item)
        {
            return item.CheckFlag == "D";
        }
        private IEnumerable<Setting> GetCategory()
        {
            var setting = db.Repository<Setting>().ReadAll()
                .Include(a => a.ParentSetting)
                .FirstOrDefault(a => a.SettingName == "ItemType" 
                        && a.ParentSetting.SettingName == SettingTypes.Category.ToString());
            var selectList = db.Repository<Setting>().ReadAll()
                .Where(a => a.ParentId == setting.ID);
                //.Select(a => new SelectListItem
                //{
                //    Value = a.Value,
                //    Text = a.Value.ToString(),
                //    Selected = string.IsNullOrEmpty(selectedValue) ? false : a.Value.ToString() == selectedValue
                //});
            foreach(var selectItem in selectList)
            {
                yield return selectItem;
            }
        }
        public void Index(CodeFileViewModel model)
        {
            model.CategoryListEvent += GetCategoryList;
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
                    codeFile = ToCreateEntity(model);
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
