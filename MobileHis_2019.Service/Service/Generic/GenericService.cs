using Common;
using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MobileHis_2019.Service
{
    public class GenericService<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IUnitOfWork db;
        public GenericService(IUnitOfWork inDB)
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
            return db.Repository<TEntity>().Read(predicate, includes);
        }

        public IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return db.Repository<TEntity>().ReadAll();
        }
        public void Create(TEntity entity)
        {
            db.Repository<TEntity>().Create(entity);
        }
        public void Create(IList<TEntity> entities)
        {
            db.Repository<TEntity>().Create(entities);
        }
        public void Delete(TEntity entity)
        {
            db.Repository<TEntity>().Delete(entity);
        }
        public void Delete(IList<TEntity> entities)
        {
            db.Repository<TEntity>().Delete(entities);
        }
        public IEnumerable<TEntity> ReadAll()
        {
            return db.Repository<TEntity>().ReadAll();
        }
        public void Update(TEntity entity)
        {
            db.Repository<TEntity>().Update(entity);
        }
        public void Save()
        {
            db.Save();
        }
        protected void DuplicatedError()
        {
            ValidationDictionary.AddGeneralError(@LocalRes.Resource.MSG_Duplidate);
        }
        protected void NotFoundError()
        {
            ValidationDictionary.AddGeneralError(LocalRes.Resource.Comm_NotFound);
        }

        /// <summary>
        /// 取得某一個條件下面的某一筆Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel或者是null</returns>
        public virtual TViewModel GetSpecificDetailToViewModel<TViewModel>(System.Linq.Expressions.Expression<Func<TEntity, bool>> wherePredicate,
            params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            return GetSpecificDetail(wherePredicate, includes).MapFrom<TEntity, TViewModel>();
        }
        /// <summary>
        /// 取得某一個條件下面的某一筆Entity
        /// </summary>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得Entity或者是null</returns>
        public virtual TEntity GetSpecificDetail(System.Linq.Expressions.Expression<Func<TEntity, bool>> wherePredicate,
            params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            var data = ApplyIncludeAndGetIQueryable(includes);

            return data.Where(wherePredicate).FirstOrDefault();
        }

        /// <summary>
        /// 取得IQueryable同時加上Include的Entity
        /// </summary>
        /// <param name="includes">要Include進來的Entity</param>
        /// <returns>加過Include的IQueryable</returns>
        private IQueryable<TEntity> ApplyIncludeAndGetIQueryable(System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            var data = db.Repository<TEntity>().ReadAll();

            foreach (var item in includes)
            {
                data.Include(item);
            }

            return data;
        }
    }
}
