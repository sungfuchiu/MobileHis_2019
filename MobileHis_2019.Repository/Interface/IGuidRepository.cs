using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository.Interface
{
    public interface IGuidRepository<TEntity> : IRepository<TEntity> where TEntity : class, IGuidEntity
    {
        void Delete(Guid guid);
        TEntity Read(Guid guid);
    }
}
