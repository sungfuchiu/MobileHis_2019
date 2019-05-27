using DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BLL
{
    public class BLLBase<TEntity> : IBLL<TEntity> where TEntity : class
    {
        public Common.IValidationDictionary ValidationDictionary { get; private set; }
        protected IEnumerable<SelectListItem> SelectList { get; set; }
        public void InitialiseIValidationDictionary(
            Common.IValidationDictionary iValidationDictionary)
        {
            ValidationDictionary = iValidationDictionary;
        }
        protected IDAL<TEntity> IDAL;
        public TEntity Read(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return IDAL.Read(predicate, includes);
        }

        public IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return IDAL.ReadAll();
        }
        public void Add(TEntity entity)
        {
            IDAL.Add(entity);
        }
        public void Add(IList<TEntity> entities)
        {
            IDAL.Add(entities);
        }
        public void Delete(TEntity entity)
        {
            IDAL.Delete(entity);
        }
        public IEnumerable<TEntity> ReadAll()
        {
            return IDAL.ReadAll();
        }
        public void Edit(TEntity entity)
        {
            IDAL.Edit(entity);
        }
        public void Save()
        {
            IDAL.Save();
        }

        public List<SelectListItem> GetDropDownList(string itemType, string selectedValue = "", bool hasEmpty = false, bool hasAll = false)
        {
            var list = new List<System.Web.Mvc.SelectListItem>();
            if (hasEmpty)
            {
                list.Add(
                    new SelectListItem {
                        Text = LocalRes.Resource.Comm_Select,
                        Value = ""
                    });
            }
            if (hasAll)
            {
                list.Add(
                    new SelectListItem {
                        Text = "ALL",
                        Value = "0"
                    });
            }
            var datalist = SelectList ?? GetSelectList(itemType, selectedValue);
            list.AddRange(datalist);
            return list;
        }
        protected virtual IEnumerable<SelectListItem> GetSelectList(string itemType, string selectedValue = "")
        {
            return new List<SelectListItem>();
        }
        protected void DuplicatedError()
        {
            ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
        }
    }
}
