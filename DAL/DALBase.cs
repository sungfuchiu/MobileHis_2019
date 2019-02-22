using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MobileHis.Data;

namespace DAL
{
    public class DALBase<T> : IDisposable where T : class
    {
        protected MobileHISEntities Entities;
        DbContextTransaction Trans;
        bool Disposed = false;
        Validation.ValidationImplement validation = new Dictionary<string, string>();

        public DALBase() { Entities = new MobileHISEntities(); }
        public DALBase(MobileHISEntities entities) { Entities = entities; }


        public virtual IQueryable<T> Filter(IQueryable<T> query, T filter)
        {
            IQueryable<T> Querydata = null;
            if (filter != null)
            {
                // Querydata = this.filter.Filter(query);
                foreach (var p in filter.GetType().GetProperties())
                {

                }
            }
            return Querydata;
        }
        public virtual IQueryable<T> Sort(IQueryable<T> query, string orderby, bool asc = true)
        {
            IQueryable<T> Querydata = null;
            if (!string.IsNullOrEmpty(orderby))
            {
                foreach (var p in query.FirstOrDefault().GetType().GetProperties())
                {
                    //if (p.Name==orderby)
                    //    Querydata=query.OrderBy(a=>a[])
                }
            }
            return Querydata;
        }
        protected virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Entities.Set<T>();
            return query;
        }
        public virtual IQueryable<T> GetAllWithNoTracking()
        {
            IQueryable<T> query = Entities.Set<T>().AsNoTracking();
            return query;
        }
        public virtual bool IsValid(T entity)
        {
            return true;
        }
        public virtual bool Add(T entity)
        {
            if (!IsValid)
                return false;
            Entities.Set<T>().Add(entity);
            Entities.SaveChanges();
            return true;
        }
        public virtual void Edit(T entity)
        {
            if (!IsValid)
                return false;
            Entities.Entry(entity).State = EntityState.Modified;
            Entities.SaveChanges();
            return true;
            //db.Entry(entity).State = System.Data.EntityState.Modified;
        }
        public virtual void Delete(IQueryable<T> deleteRange)
        {
            foreach (var o in deleteRange)
            {
                Delete(o);
            }
            Entities.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            Entities.Set<T>().Remove(entity);
            Entities.SaveChanges();
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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
