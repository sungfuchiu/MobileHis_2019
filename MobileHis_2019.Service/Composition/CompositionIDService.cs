using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Composition
{
    public class CompositionIDService<TEntity> where TEntity : class, IIDEntity
    {
        private IUnitOfWork db;
        public CompositionIDService(IUnitOfWork inDB)
        {
            db = inDB;
        }
        public virtual void Delete(int ID)
        {
            var entity = db.Repository<TEntity>().Read(a => a.ID == ID);
            db.Repository<TEntity>().Delete(entity);
        }
        public virtual TEntity Read(int ID)
        {
            return db.Repository<TEntity>().Read(a => a.ID == ID);
        }
    }
}
