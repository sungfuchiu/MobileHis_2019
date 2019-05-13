using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL<TEntity>
    {
        TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Reads(params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        void Add(IList<TEntity> entites);
        IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes);
        void Delete(TEntity entity);
        void Save();
    }
}
