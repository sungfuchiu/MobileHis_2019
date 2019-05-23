using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GuidDALBase<TEntity> : BLLBase<TEntity>, IGuidBLL<TEntity> where TEntity : class, MobileHis.Data.Interface.IGuidEntity
    {

        public void Delete(Guid guid)
        {
            Delete(guid);
        }
        public TEntity Read(Guid guid)
        {
            return Read(guid);
        }
    }
    public class IDBLLBase<TEntity> : BLLBase<TEntity>, IIDBLL<TEntity> where TEntity : class, MobileHis.Data.Interface.IIDEntity
    {
        public virtual void Delete(int ID)
        {
            Delete(ID);
        }
        public TEntity Read(int ID)
        {
            return Read(ID);
        }
    }
}
