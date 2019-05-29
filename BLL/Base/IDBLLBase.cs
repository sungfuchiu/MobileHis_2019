using BLL.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GuidBLLBase<TEntity> : BLLBase<TEntity>, IGuidBLL<TEntity> where TEntity : class, MobileHis.Data.Interface.IGuidEntity
    {
        private IGuidDAL<TEntity> _IDAL;
        protected new IGuidDAL<TEntity> IDAL
        {
            get => _IDAL;
            set
            {
                base.IDAL = value;
                _IDAL = value;
            }
        }
        public void Delete(Guid guid)
        {
            IDAL.Delete(guid);
            IDAL.Save();
        }
        public TEntity Read(Guid guid)
        {
            return IDAL.Read(guid);
        }
    }
    public class IDBLLBase<TEntity> : BLLBase<TEntity>, IIDBLL<TEntity> where TEntity : class, MobileHis.Data.Interface.IIDEntity
    {
        private IIDDAL<TEntity> _IDAL;
        protected new IIDDAL<TEntity> IDAL
        {
            get => _IDAL;
            set
            {
                base.IDAL = value;
                _IDAL = value;
            }
        }
        public virtual void Delete(int ID)
        {
            IDAL.Delete(ID);
            IDAL.Save();
        }
        public virtual TEntity Read(int ID)
        {
            return IDAL.Read(ID);
        }
    }
}
