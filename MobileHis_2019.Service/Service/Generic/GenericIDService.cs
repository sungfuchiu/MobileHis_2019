using MobileHis_2019.Repository.Interface;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service
{
    public class GenericIDService<TEntity> : GenericService<TEntity>, IIDService<TEntity> where TEntity : class, MobileHis.Data.IIDEntity
    {
        public GenericIDService(IUnitOfWork inDB) : base(inDB) { }
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
