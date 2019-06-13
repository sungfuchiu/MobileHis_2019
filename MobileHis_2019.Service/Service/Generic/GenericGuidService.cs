using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    public class GenericGuidService<TEntity> : GenericService<TEntity>, IGuidService<TEntity> where TEntity : class, MobileHis.Data.IGuidEntity
    {
        public GenericGuidService(IUnitOfWork inDB) : base(inDB) { }
        public virtual void Delete(Guid GID)
        {
            var entity = db.Repository<TEntity>().Read(a => a.GID == GID);
            db.Repository<TEntity>().Delete(entity);
        }
        public virtual TEntity Read(Guid GID)
        {
            return db.Repository<TEntity>().Read(a => a.GID == GID);
        }
    }
}
