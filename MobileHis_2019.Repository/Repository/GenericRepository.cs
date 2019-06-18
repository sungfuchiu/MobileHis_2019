using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository
{
     public class GenericRepository<TEntity> : IRepository<TEntity>
         where TEntity : class
     {
            private DbContext _context
            {
                get;
                set;
            }

            public GenericRepository()
                : this(new MobileHISEntities())
            {
            }
            public GenericRepository(DbContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                this._context = context;
            }

            public GenericRepository(ObjectContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                this._context = new DbContext(context, true);
            }



            /// <summary>
            /// Creates the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <exception cref="System.ArgumentNullException">entity</exception>
            public void Create(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                else
                {
                    this._context.Set<TEntity>().Add(entity);
                }

            }
            public void Create(IList<TEntity> entities)
            {
                foreach(var entity in entities)
                {
                    this._context.Set<TEntity>().Add(entity);
                }
            }
            public void Create(IQueryable<TEntity> entities)
            {
                this._context.Set<TEntity>().AddRange(entities);
            }

            /// <summary>
            /// Updates the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void Update(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                else
                {
                    this._context.Entry(entity).State = EntityState.Modified;
                }
            }

            /// <summary>
            /// Deletes the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void Delete(TEntity entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                else
                {
                    if (entity is IIsDeleted)
                    {
                        ((IIsDeleted)entity).IsDeleted = true;
                    }
                    else
                    {
                        this._context.Entry(entity).State = EntityState.Deleted;
                    }
                }
            }
        /// <summary>
        /// Deletes entities.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(IList<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
            {
                var entity = _context.Set<TEntity>().AsQueryable();
                foreach(var item in includes)
                {
                    entity.Include(item);
                }
                return entity.FirstOrDefault(predicate);
            }

            /// <summary>
            /// Gets all.
            /// </summary>
            /// <returns></returns>
            public IQueryable<TEntity> ReadAll()
            {
                return this._context.Set<TEntity>().AsQueryable();
            }

        

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (this._context != null)
                    {
                        this._context.Dispose();
                        this._context = null;
                    }
                }
            }
        }
}
