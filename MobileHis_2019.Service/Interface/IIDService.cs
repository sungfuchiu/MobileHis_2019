using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;
using MobileHis_2019.Service.Composition;

namespace MobileHis_2019.Service.Interface
{
    public interface IIDService<TEntity> : IService<TEntity> where TEntity : IIDEntity
    {
        void Delete(int ID);
        TEntity Read(int ID);
    }
    public interface IIDServiceComposition<TEntity> where TEntity : class, IIDEntity
    {
        CompositionIDService<TEntity> IDService { get; set; }
    }
}
