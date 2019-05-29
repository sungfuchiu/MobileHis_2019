using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data.Interface;

namespace DAL
{
    public interface IGuidDAL<TEntity> :IDAL<TEntity> where TEntity : IGuidEntity
    {
        void Delete(Guid guid);
        TEntity Read(Guid guid);
    }
    public interface IIDDAL<TEntity> : IDAL<TEntity> where TEntity : IIDEntity
    {
        void Delete(int ID);
        TEntity Read(int ID);
    }
}
