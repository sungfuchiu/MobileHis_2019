using BLL.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GuidBLLBase<TEntity> : BLLBase<TEntity>, IGuidBLL<TEntity> where TEntity : class, MobileHis.Data.IGuidEntity
    {
        public GuidBLLBase(IUnitOfWork inDB) : base(inDB) { }
        public virtual void Delete(Guid ID)
        {
            db.GuidDAL<TEntity>().Delete(ID);
        }
        public virtual TEntity Read(Guid ID)
        {
            return db.GuidDAL<TEntity>().Read(ID);
        }
        //private IGuidDAL<TEntity> _IDAL;
        //protected new IGuidDAL<TEntity> IDAL
        //{
        //    get => _IDAL;
        //    set
        //    {
        //        base.IDAL = value;
        //        _IDAL = value;
        //    }
        //}
        //public void Delete(Guid guid)
        //{
        //    IDAL.Delete(guid);
        //    IDAL.Save();
        //}
        //public TEntity Read(Guid guid)
        //{
        //    return IDAL.Read(guid);
        //}
    }
    public class IDBLLBase<TEntity> : BLLBase<TEntity>, IIDBLL<TEntity> where TEntity : class, MobileHis.Data.IIDEntity
    {
        public IDBLLBase(IUnitOfWork inDB) : base(inDB) { }
        public virtual void Delete(int ID)
        {
            db.IDDAL<TEntity>().Delete(ID);
        }
        public virtual TEntity Read(int ID)
        {
            return db.IDDAL<TEntity>().Read(ID);
        }
        //private IIDDAL<TEntity> _IDAL;
        //protected IIDDAL<TEntity> IDAL
        //{
        //    get => _IDAL;
        //    set
        //    {
        //        IDAL<TEntity> iDAL = base.db.DAL<TEntity>();
        //        iDAL = value;
        //        _IDAL = value;
        //    }
        //}
        //public virtual void Delete(int ID)
        //{
        //    IDAL.Delete(ID);
        //    IDAL.Save();
        //}
        //public virtual TEntity Read(int ID)
        //{
        //    return IDAL.Read(ID);
        //}
    }
}
