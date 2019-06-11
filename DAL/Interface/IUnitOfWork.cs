using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IDAL<T> DAL<T>() where T : class;
        IIDDAL<T> IDDAL<T>() where T : class, IIDEntity;
        IGuidDAL<T> GuidDAL<T>() where T : class, IGuidEntity;
    }
}
