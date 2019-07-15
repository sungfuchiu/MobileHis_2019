using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IRepository<T> Repository<T>() where T : class;
        DbContextTransaction BeginTransaction();
        //void Commit();
        //void RollBack();
        //void DisposeTransaction();

        //IIDRepository<T> IDRepository<T>() where T : class, IIDEntity;
        //IGuidRepository<T> GuidRepository<T>() where T : class, IGuidEntity;
    }
}
