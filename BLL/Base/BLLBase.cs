using DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;
using System.Web.Mvc;
using MobileHis.Data;

namespace BLL
{
    public class BLLBase<TEntity> : IBLL<TEntity> where TEntity : class
    {
        //protected IDAL<TEntity> IDAL;
        protected IUnitOfWork db;
        public BLLBase(IUnitOfWork inDB)
        {
            db = inDB;
        }
        public Common.IValidationDictionary ValidationDictionary { get; private set; }
        public void InitialiseIValidationDictionary(
            Common.IValidationDictionary iValidationDictionary)
        {
            ValidationDictionary = iValidationDictionary;
        }
        public TEntity Read(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return db.DAL<TEntity>().Read(predicate, includes);
        }

        public IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return db.DAL<TEntity>().ReadAll();
        }
        public void Add(TEntity entity)
        {
            db.DAL<TEntity>().Add(entity);
        }
        public void Add(IList<TEntity> entities)
        {
            db.DAL<TEntity>().Add(entities);
        }
        public void Delete(TEntity entity)
        {
            if (entity is IIsDeleted)
            {
                ((IIsDeleted)entity).IsDeleted = true;
            }
            else
            {
                db.DAL<TEntity>().Delete(entity);
            }
        }
        public IEnumerable<TEntity> ReadAll()
        {
            return db.DAL<TEntity>().ReadAll();
        }
        public void Edit(TEntity entity)
        {
            db.DAL<TEntity>().Edit(entity);
        }
        public void Save()
        {
            db.DAL<TEntity>().Save();
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
            var datalist = GetSelectList(itemType, selectedValue, onlyRegistered, userID);
            list.AddRange(datalist);
            return list;
        }
        protected virtual IEnumerable<SelectListItem> GetSelectList(
            string itemType = "", 
            string selectedValue = "", 
            bool onlyRegistered = false, 
            int userID = 0)
        {
            return new List<SelectListItem>();
        }
        protected void DuplicatedError()
        {
            ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
        }
        protected void NotFoundError()
        {
            ValidationDictionary.AddGeneralError(LocalRes.Resource.Comm_NotFound);
        }
    }
}
