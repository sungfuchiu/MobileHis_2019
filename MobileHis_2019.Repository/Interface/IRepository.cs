using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        void Create(IList<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(IList<TEntity> entities);

        TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> ReadAll();
        
    }
}
