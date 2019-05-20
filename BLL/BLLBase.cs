using DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;

namespace BLL
{
    public class BLLBase<TEntity> : IBLL<TEntity> where TEntity : class
    {
        public Common.IValidationDictionary ValidationDictionary { get; private set; }
        public void InitialiseIValidationDictionary(
            Common.IValidationDictionary iValidationDictionary)
        {
            ValidationDictionary = iValidationDictionary;
        }
        protected IDAL<TEntity> IDAL;
        public TEntity Read(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return IDAL.Read(predicate, includes);
        }

        public IEnumerable<TEntity> ReadAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return IDAL.ReadAll();
        }
        public void Add(TEntity entity)
        {
            IDAL.Add(entity);
        }
        public void Add(IList<TEntity> entities)
        {
            IDAL.Add(entities);
        }
        public void Delete(TEntity entity)
        {
            IDAL.Delete(entity);
        }
        public IEnumerable<TEntity> ReadAll()
        {
            return IDAL.ReadAll();
        }
        public void Edit(TEntity entity)
        {
            IDAL.Edit(entity);
        }
    }
}
