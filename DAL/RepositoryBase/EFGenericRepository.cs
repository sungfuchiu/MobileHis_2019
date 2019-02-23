using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity :class
    {
        private DbContext Context { get; set; }
        public EFGenericRepository(DbContext entityContext)
        {
            Context = entityContext;
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
        public TEntity ReadWithNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().AsNoTracking().Where(predicate).FirstOrDefault();
        }
        public IQueryable<TEntity> Reads()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            Context.Configuration.ValidateOnSaveEnabled = false;
            Context.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if(updateProperties != null)
            {
                foreach(var property in updateProperties)
                {
                    Context.Entry<TEnttiy>(entity).Property(property).IsModified = true;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
            if(Context.Configuration.ValidateOnSaveEnabled == false)
            {
                Context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

    }
}
