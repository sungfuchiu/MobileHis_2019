using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository.Interface
{
    public interface IIDRepository<TEntity> : IRepository<TEntity> where TEntity : class, IIDEntity
    {
        void Delete(int ID);
        TEntity Read(int ID);
    }
}
