using BLL.Interface;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GuidBLLBase<TEntity> : BLLBase<TEntity>, IGuidBLL<TEntity> where TEntity : class, MobileHis.Data.Interface.IGuidEntity
    {
        protected new IGuidDAL<TEntity> IDAL;
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
        protected new IIDDAL<TEntity> IDAL;
        public virtual void Delete(int ID)
        {
            IDAL.Delete(ID);
            IDAL.Save();
        }
        public TEntity Read(int ID)
        {
            return IDAL.Read(ID);
        }
    }
}
