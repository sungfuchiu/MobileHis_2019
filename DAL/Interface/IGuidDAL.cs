using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGuidDAL<TEntity> :IDAL<TEntity>
    {
        void Delete(Guid guid);
        TEntity Read(Guid guid);
    }
}
