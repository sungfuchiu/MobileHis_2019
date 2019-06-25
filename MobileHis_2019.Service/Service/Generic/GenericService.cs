using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
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
    }
}
