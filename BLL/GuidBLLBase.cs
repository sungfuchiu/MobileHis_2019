using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GuidBLLBase<TEntity> : BLLBase<TEntity> where TEntity : class, MobileHis.Data.Interface.IGuidEntity
    {
        //protected IGuidDAL<TEntity> IDAL
        //{
        //    get
        //    {
        //        return (IGuidDAL<TEntity>)base.IDAL;
        //    }
        //    set
        //    {
        //        base.IDAL = value;
        //    }
        //}
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
}
