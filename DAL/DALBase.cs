using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MobileHis.Data;
using System.Linq.Expressions;

namespace DAL
{
    //public class DatabaseValidationErrors : Exception
    //{
    //    public DatabaseValidationErrors()
    //}
    public class DALBase<TEntity> : IDAL<TEntity>, IDisposable where TEntity : class
    {
        protected MobileHISEntities Entities;
        DbContextTransaction Trans;
        bool Disposed = false;
        Validation.ValidationImplement validation = new Validation.ValidationImplement(new Dictionary<string, string>());
        public IQueryable<TEntity> Entity;
        public IQueryable<string> Data;

        public DALBase() { Entities = new MobileHISEntities(); }
        public DALBase(MobileHISEntities entities) { Entities = entities; }


        public virtual IQueryable<TEntity> Filter(IQueryable<TEntity> query, TEntity filter)
        {
            IQueryable<TEntity> Querydata = null;
            if (filter != null)
            {
                // Querydata = this.filter.Filter(query);
                foreach (var p in filter.GetType().GetProperties())
                {

                }
            }
            return Querydata;
        }
        public virtual void Sort<TKey>(IQueryable<TEntity> query, bool asc = true, params Expression<Func<TEntity, TKey>>[] ordersBy)
        {
            //IQueryable<TEntity> Querydata = null;
            foreach(var orderBy in ordersBy)
            {
                Entity.OrderBy(orderBy);
            }
            //if (!string.IsNullOrEmpty(orderby))
            //{
            //    foreach (var p in query.FirstOrDefault().GetType().GetProperties())
            //    {
            //        //if (p.Name==orderby)
            //        //    Querydata=query.OrderBy(a=>a[])
            //    }
            //}
            //return Querydata;
        }
        public virtual IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IEnumerable<TEntity> query = Entities.Set<TEntity>();
            return query;
        }
        public virtual IQueryable<TEntity> GetAllWithNoTracking()
        {
            IQueryable<TEntity> query = Entities.Set<TEntity>().AsNoTracking();
            return query;
        }
        public TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return Entities.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
        public void Reads(params Expression<Func<TEntity, object>>[] includes)
        {
            Entity = Entities.Set<TEntity>().AsQueryable();
            foreach(var item in includes)
            {
                Entity.Include(item);
            }
        }
        public IQueryable<T> Select<T>(Expression<Func<TEntity, T>> select)
        {
            return Entity.Select(select);
        }
        public IQueryable<T> Distinct<T>(IQueryable<T> source)
        {
            return source.Distinct();
        }
        public IEnumerable<TEntity> ReadsResult()
        {
            return Entity.ToList();
        }
        public IEnumerable<T> ReadsResult<T>(IQueryable<T> source)
        {
            return source.ToList();
        }
        public void Add(TEntity entity)
        {
            Entities.Set<TEntity>().Add(entity);
        }
        public void Add(IList<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                Entities.Set<TEntity>().Add(entity);
            }
        }
        public void Edit(TEntity entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }
        public void Edit(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            Entities.Configuration.ValidateOnSaveEnabled = false;

            Entities.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    Entities.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }
        }
        public void Delete(IQueryable<TEntity> deleteRange)
        {
            foreach (var o in deleteRange)
            {
                Delete(o);
            }
            Entities.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            Entities.Set<TEntity>().Remove(entity);
        }

        public void Save()
        {
            var errors = Entities.GetValidationErrors();
            if (!errors.Any())
            {
                Entities.SaveChanges();
                if(Entities.Configuration.ValidateOnSaveEnabled == false)
                    Entities.Configuration.ValidateOnSaveEnabled = true;
            }
            else
            {
                //throw new DatabaseValidationErrors(errors);
                throw new Exception("DBError");
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                Entities.Dispose();
                Entities = null;
                Disposed = true;
            }
        }

    }
}
