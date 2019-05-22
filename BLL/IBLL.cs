using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL<TEntity>
    {
        TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> ReadAll();
        void Create(TEntity entity);
        void Add(IList<TEntity> entites);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
