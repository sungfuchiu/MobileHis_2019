using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data.Interface;

namespace BLL.Interface
{
    public interface IGuidBLL<TEntity> : IBLL<TEntity> where TEntity : IGuidEntity
    {
        void Delete(Guid guid);
        TEntity Read(Guid guid);
    }
    public interface IIDBLL<TEntity> : IBLL<TEntity> where TEntity : IIDEntity
    {
        void Delete(int ID);
        TEntity Read(int ID);
    }
}
