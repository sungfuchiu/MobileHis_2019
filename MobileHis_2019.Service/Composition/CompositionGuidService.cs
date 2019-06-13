using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Composition
{
    public class CompositionGuidService<TEntity> where TEntity : class, IGuidEntity
    {
        private IUnitOfWork db;
        public CompositionGuidService(IUnitOfWork inDB)
        {
            db = inDB;
        }
        public virtual void Delete(Guid guid)
        {
            var entity = db.Repository<TEntity>().Read(a => a.GID == guid);
            db.Repository<TEntity>().Delete(entity);
        }
        public virtual TEntity Read(Guid guid)
        {
            return db.Repository<TEntity>().Read(a => a.GID == guid);
        }
    }
}
